using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebTokenGenerator.Core
{
    public class HttpService : IDisposable
    {
        private List<Task> currentTasks = new List<Task>();
        private readonly HttpListener httpListener;
        private readonly Func<HttpListenerRequest, StreamWriter, Task> handleClientRequest;
        private CancellationTokenSource cancellationTokenSource;
        public HttpService(string serverAndPort, 
            Func<HttpListenerRequest, StreamWriter, Task> handleClientRequest)
        {
            httpListener = new HttpListener();
            httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            httpListener.Prefixes.Add(serverAndPort);
            this.handleClientRequest = handleClientRequest;
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

        public async Task Start(CancellationToken cancellationToken = default)
        {
            if(cancellationToken == default)
            {
                cancellationTokenSource = new CancellationTokenSource();
                cancellationToken = cancellationTokenSource.Token;
            }

            httpListener.Start();

            while (!cancellationToken.IsCancellationRequested || httpListener.IsListening)
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
        }

        private async Task ProcessRequest(HttpListenerContext context)
        {
            context.Response.StatusCode = 200;
            context.Response.ContentType = "application/json";
            var textWriter = new StreamWriter(context.Response.OutputStream);
            await handleClientRequest.Invoke(context.Request, textWriter);
            await textWriter.FlushAsync();
            context.Response.Close();
        }

        public void Dispose()
        {
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
