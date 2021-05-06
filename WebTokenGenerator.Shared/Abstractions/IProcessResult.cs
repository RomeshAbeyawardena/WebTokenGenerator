using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebTokenGenerator.Shared.Abstractions
{
    public interface IProcessResult
    {
        bool Successful { get; }
        Exception Exception { get; }
    }

    public interface IProcessResult<TResult> : IProcessResult
    {
        TResult Result { get; }
    }
}
