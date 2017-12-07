using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IManureDensity
    {
        public long DensityId { get; set; }
        public long Imanure { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public string LorS { get; set; }
        public decimal? Cylinder { get; set; }
        public decimal? CylplusWater { get; set; }
        public decimal? SampleplusCylinder { get; set; }
        public decimal? SampplusCylplusWater { get; set; }
        public decimal? Calc { get; set; }
        public bool? Averaged { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IManure ImanureNavigation { get; set; }
    }
}
