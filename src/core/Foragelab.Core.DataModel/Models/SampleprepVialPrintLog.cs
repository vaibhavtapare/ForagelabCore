using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SampleprepVialPrintLog
    {
        public int VialPrintLogId { get; set; }
        public string LabId { get; set; }
        public DateTime? PrintedDate { get; set; }
        public bool? Status { get; set; }
    }
}
