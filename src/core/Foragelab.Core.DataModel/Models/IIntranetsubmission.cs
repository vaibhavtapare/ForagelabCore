using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IIntranetsubmission
    {
        public long Id { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public bool? IsFermentation { get; set; }
        public bool? IsFatty { get; set; }
        public bool? IsToxin { get; set; }
        public bool? IsMoldId { get; set; }
        public bool? IsParticleSize { get; set; }
        public bool? IsNdfd { get; set; }
    }
}
