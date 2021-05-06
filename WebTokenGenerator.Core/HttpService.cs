using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebTokenGenerator.Shared.Abstractions;
using WebTokenGenerator.Shared.Domain;

namespace WebTokenGenerator.Core
{
    public class HttpService : IHttpService
    {
        private List<Task> currentTasks = new List<Task>();
        private readonly HttpListener httpListener;
        private readonly ILogger logger;
        private Func<HttpListenerRequest, StreamWriter, Task<ProcessResult>> handleClientRequest;
        private CancellationTokenSource cancellationTokenSource;
        
        public HttpService(ILogger<IHttpService> logger)
        {
            httpListener = new HttpListener();
            
            this.logger = logger;
            
        }

        public bool IsRunning => httpListener.IsListening;

        public void Stop()
        {
            if(cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }

            httpListener.Stop();
        }

        public async Task Start(string serverAndPort,
            Func<HttpListenerRequest, StreamWriter, Task<ProcessResult>> handleClientRequest,
            AuthenticationSchemes authenticationSchemes = AuthenticationSchemes.Anonymous,
            CancellationToken cancellationToken = default)
        {
            httpListener.AuthenticationSchemes = authenticationSchemes;
            httpListener.Prefixes.Add(serverAndPort);
            this.handleClientRequest = handleClientRequest;

            if (cancellationToken == default)
            {
                cancellationTokenSource = new CancellationTokenSource();
                cancellationToken = cancellationTokenSource.Token;
            }

            httpListener.Start();

            while (httpListener.IsListening &&
                !cancellationToken.IsCancellationRequested)
            {
                try
                {
                    Debug.WriteLine("Waiting for a connection");
                    var context = await httpListener.GetContextAsync();

                    var task = Task.Run(async () => await ProcessRequest(context));

                    Debug.WriteLine($"processing connection request {task.Id}");
                    currentTasks.Add(task);

                    for (int i = 0; i < currentTasks.Count; i++)
                    {
                        var currentTask = currentTasks[i];
                        if (currentTask.IsCompleted)
                        {
                            Debug.WriteLine($"removed task {currentTask.Id}");
                            currentTasks.Remove(currentTask);
                        }
                    }
                    Debug.WriteLine("EOL within while loop");
                }
                catch (HttpListenerException exception)
                {
                    logger.LogError(exception, "Exception while awaiting a connection");
                    break;
                }
            }
        }

        private async Task ProcessRequest(HttpListenerContext context)
        {
            try
            {
                var textWriter = new StreamWriter(context.Response.OutputStream);

                var result = await handleClientRequest
                    .Invoke(context.Request, textWriter);

                if (!result.Successful)
                {
                    throw result.Exception;
                }

                await textWriter.FlushAsync();
                context.Response.StatusCode = 200;
                context.Response.ContentType = "application/json";
                context.Response.Close();
            }
            catch(Exception exception)
            {
                context.Response.StatusCode = 500;
                context.Response.StatusDescription = exception.Message;
                context.Response.Close();
            }
        }

        public void Dispose()
        {
            httpListener.Abort();
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool gc)
        {
            if (gc)
            {
                Dispose();
            }

        }
    }
}
