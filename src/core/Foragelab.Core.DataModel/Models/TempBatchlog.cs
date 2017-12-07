using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class TempBatchlog
    {
        public int Batchlogid { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Nextcode { get; set; }
        public string Lab { get; set; }
        public DateTime? Batchdate { get; set; }
        public string Describe { get; set; }
    }
}
