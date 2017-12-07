using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IAnDfom
    {
        public long IanDfomId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public bool? Release { get; set; }
        public decimal? IaNdf { get; set; }
        public decimal? ANdfom { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
