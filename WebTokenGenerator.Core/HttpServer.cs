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
    public class HttpServer : IHttpServer
    {
        private List<Task> currentTasks = new List<Task>();
        private readonly HttpListener httpListener;
        private readonly ILogger logger;
        private Func<HttpListenerRequest, StreamWriter, Task<IProcessResult<ContentResult>>> handleClientRequest;
        private Func<Exception, StreamWriter, Task<ContentResult>> handleClientException;
        private CancellationTokenSource cancellationTokenSource;
        
        public HttpServer(ILogger<IHttpServer> logger)
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
            Func<HttpListenerRequest, StreamWriter, Task<IProcessResult<ContentResult>>> handleClientRequest,
            Func<Exception, StreamWriter, Task<ContentResult>> handleClientException = default,
            AuthenticationSchemes authenticationSchemes = AuthenticationSchemes.Anonymous,
            CancellationToken cancellationToken = default)
        {
            httpListener.AuthenticationSchemes = authenticationSchemes;
            httpListener.Prefixes.Add(serverAndPort);
            this.handleClientRequest = handleClientRequest;
            this.handleClientException = handleClientException;

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
                    logger.LogTrace("Waiting for a connection");
                    var context = await httpListener.GetContextAsync();

                    var task = Task.Run(async () => await ProcessRequest(context));

                    logger.LogTrace($"processing connection request {task.Id}");
                    currentTasks.Add(task);

                    for (int i = 0; i < currentTasks.Count; i++)
                    {
                        var currentTask = currentTasks[i];
                        if (currentTask.IsCompleted)
                        {
                            logger.LogTrace($"removed task {currentTask.Id}");
                            currentTasks.Remove(currentTask);
                        }
                    }

                    logger.LogTrace("EOL within while loop");
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
            IProcessResult<ContentResult> response = default;
            var textWriter = new StreamWriter(context.Response.OutputStream);
            try
            {
                response = await handleClientRequest
                    .Invoke(context.Request, textWriter);

                if (!response.Successful)
                {
                    throw response.Exception;
                }

                await textWriter.FlushAsync();
                context.Response.StatusCode = response.Result.StatusCode;
                context.Response.StatusDescription = response.Result.StatusDescription;
                context.Response.ContentType = response.Result.ContentType;
                context.Response.Close();
            }
            catch(Exception exception)
            {
                var result = await (handleClientException?.Invoke(exception, textWriter) 
                    ?? Task.FromResult<ContentResult>(default));

                context.Response.StatusCode = response?.Result.StatusCode 
                    ?? result?.StatusCode 
                    ?? 500;

                context.Response.StatusDescription = response?.Result?.StatusDescription 
                    ?? result?.StatusDescription 
                    ?? exception.Message;

                context.Response.ContentType = response?.Result?.ContentType 
                    ?? result?.ContentType 
                    ?? string.Empty;

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
