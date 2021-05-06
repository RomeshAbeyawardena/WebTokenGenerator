using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTokenGenerator.Shared.Domain
{
    public class ProcessResult
    {
        public static ProcessResult Success()
        {
            return new ProcessResult(true);
        }

        public static ProcessResult Fail(Exception exception)
        {
            return new ProcessResult(exception);
        }

        public ProcessResult(bool successful)
        {
            Successful = successful;
        }

        public ProcessResult(Exception exception)
            : this(false)
        {
            Exception = exception;
        }

        public bool Successful { get; }
        public Exception Exception { get; }
    }
}
