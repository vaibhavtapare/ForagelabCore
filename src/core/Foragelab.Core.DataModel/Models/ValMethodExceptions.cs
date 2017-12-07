using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ValMethodExceptions
    {
        public long ExceptionId { get; set; }
        public long? ExceptionMethodTypeId { get; set; }
        public string ExceptionName { get; set; }
        public long? FeedCode { get; set; }
        public string ExceptoinCase { get; set; }
        public int? OrderBy { get; set; }
        public string Output { get; set; }
        public bool? IsActive { get; set; }

        public ValMethodTypes ExceptionMethodType { get; set; }
    }
}
