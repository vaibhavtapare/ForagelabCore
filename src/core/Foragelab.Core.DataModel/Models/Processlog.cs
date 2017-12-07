using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Processlog
    {
        public long ProcessLogId { get; set; }
        public string ProcessName { get; set; }
        public string ProcessDescription { get; set; }
        public int? RecordsInserted { get; set; }
        public int? RecordsUpdated { get; set; }
        public string ProcessError { get; set; }
        public DateTime? ProcessDate { get; set; }
    }
}
