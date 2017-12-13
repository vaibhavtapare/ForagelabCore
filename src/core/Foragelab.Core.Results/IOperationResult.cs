using System;
using System.Collections.Generic;
using System.Text;

namespace Foragelab.Core.Results
{
    public interface IOperationResult
    {
        OperationResultCode Code { get; set; }
        string Message { get; set; }
        string StackTrace { get; }
        Dictionary<string, string> ValidationErrors { get; set; }
        Exception Exception { get; set; }

        void CopyException(Exception exception);
        void CopyFrom(IOperationResult opResult);
    }
}
