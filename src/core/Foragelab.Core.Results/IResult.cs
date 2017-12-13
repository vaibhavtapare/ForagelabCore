using System;
using System.Collections.Generic;
using System.Text;

namespace Foragelab.Core.Results
{
    public interface IResult<T> : IOperationResult
    {
        T Result
        {
            get;
            set;
        }
    }
}
