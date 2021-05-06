using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebTokenGenerator.Shared.Domain;

namespace WebTokenGenerator.Shared.Abstractions
{
    public interface IHttpServer : IDisposable
    {
        Task Start(string serverAndPort,
            Func<HttpListenerRequest, StreamWriter, Task<IProcessResult<ContentResult>>> handleClientRequest,
            Func<Exception, StreamWriter, Task<ContentResult>> handleClientException = default,
            AuthenticationSchemes authenticationSchemes = AuthenticationSchemes.Anonymous,
            CancellationToken cancellationToken = default);
        bool IsRunning { get; }
        void Stop();
    }
}
