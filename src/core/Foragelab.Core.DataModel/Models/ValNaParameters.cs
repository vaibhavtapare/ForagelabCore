using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ValNaParameters
    {
        public int ValidateBatchId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? FromCode { get; set; }
        public decimal? ToCode { get; set; }
        public decimal? StdDev { get; set; }
        public bool? UseBias { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? DataTransferStatus { get; set; }
    }
}
