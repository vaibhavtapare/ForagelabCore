using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class LogFaxes
    {
        public int FaxLogId { get; set; }
        public Guid FaxId { get; set; }
        public string LabId { get; set; }
        public string FaxNumber { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
