using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebTokenGenerator.Shared.Abstractions;

namespace WebTokenGenerator.Shared.Domain
{
    public class ProcessResult : IProcessResult
    {
        public static IProcessResult<TResult> Success<TResult>(TResult result)
        {
            return new ProcessResult<TResult>(result);
        }

        public static IProcessResult Success()
        {
            return new ProcessResult(true);
        }

        public static IProcessResult Fail(Exception exception)
        {
            return new ProcessResult(exception);
        }

        public static IProcessResult<TResult> Fail<TResult>(Exception exception,
            TResult result = default)
        {
            return new ProcessResult<TResult>(exception, result);
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

    public class ProcessResult<TResult> : ProcessResult, IProcessResult<TResult>
    {
        public ProcessResult(TResult result)
            : base(true)
        {
            Result = result;
        }

        public ProcessResult(Exception exception, 
            TResult result = default)
            : base(exception)
        {
            Result = result;
        }

        public TResult Result { get; }
    }
}
