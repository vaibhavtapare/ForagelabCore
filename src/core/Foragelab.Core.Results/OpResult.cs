using Foragelab.Core.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Foragelab.Core.Results
{
    public class OpResult<T> : OperationResult, IResult<T>, IOperationResult
    {
        public T Result
        {
            get;
            set;
        }
    }
}
