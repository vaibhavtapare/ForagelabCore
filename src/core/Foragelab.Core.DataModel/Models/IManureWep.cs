using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IManureWep
    {
        public long Wepid { get; set; }
        public long Imanure { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Crucible { get; set; }
        public decimal? CruplusSample { get; set; }
        public decimal? CruplusLiquid { get; set; }
        public decimal? Phos { get; set; }
        public decimal? Calculation { get; set; }
        public bool? Averaged { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IManure ImanureNavigation { get; set; }
    }
}
