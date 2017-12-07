using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IParticlesizeanalysis
    {
        public long ParticleSizeId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? SieveUpper { get; set; }
        public decimal? SieveMiddle { get; set; }
        public decimal? SieveLower { get; set; }
        public decimal? SieveBottomPan { get; set; }
        public decimal? RemainingUpper { get; set; }
        public decimal? RemainingMiddle { get; set; }
        public decimal? RemainingLower { get; set; }
        public decimal? RemainingBottomPan { get; set; }
        public decimal? CumulativeUpper { get; set; }
        public decimal? CumulativeMiddle { get; set; }
        public decimal? CumulativeLower { get; set; }
        public decimal? CumulativeBottomPan { get; set; }
        public decimal? AverageParticleSize { get; set; }
        public decimal? StandardDeviation { get; set; }
        public bool? Release { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IParticlesizeanalysis ParticleSize { get; set; }
        public IParticlesizeanalysis InverseParticleSize { get; set; }
    }
}
