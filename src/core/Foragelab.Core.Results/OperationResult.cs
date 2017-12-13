using System;
using System.Collections.Generic;


namespace Foragelab.Core.Results
{
    public class OperationResult : IOperationResult
    {       
            public OperationResultCode Code
            {
                get;
                set;
            }

            public string Message
            {
                get
                {
                    if (string.IsNullOrEmpty(this._message) && this.Exception != null)
                    {
                        return this.Exception.Message.ToString();
                    }
                    return this._message;
                }
                set
                {
                    this._message = value;
                }
            }

            private string _message
            {
                get;
                set;
            }

            public Dictionary<string, string> ValidationErrors
            {
                get;
                set;
            }

            public string StackTrace
            {
                get
                {
                    if (this.Exception == null || string.IsNullOrEmpty(this.Exception.StackTrace.ToString()))
                    {
                        return "";
                    }
                    return this.Exception.StackTrace.ToString();
                }
            }

            public Exception Exception
            {
                get
                {
                    return this._exception;
                }
                set
                {
                    if (value != null)
                    {
                        while (value.InnerException != null)
                        {
                            value = value.InnerException; 
                        }
                    }
                    this._exception = value;
                }
            }

            private Exception _exception
            {
                get;
                set;
            }

            public OperationResult()
            {
                this.Code = OperationResultCode.Success;
                this.ValidationErrors = new Dictionary<string, string>();
            }

            public OperationResult(string message)
            {
                this.Code = OperationResultCode.Success;
                this.ValidationErrors = new Dictionary<string, string>();
                this.Message = message;
            }

            public void CopyFrom(IOperationResult opResult)
            {
                this.Code = opResult.Code;
                this.Message = opResult.Message;
                this.Exception = opResult.Exception;
                if (opResult.ValidationErrors != null)
                {
                    this.ValidationErrors = opResult.ValidationErrors;
                }
            }

            public void CopyException(Exception exception)
            {
                this._message = null;
                this.Exception = exception;
                this.Code = OperationResultCode.Error;
            }
        
    }
}
