using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Qualitative
    {
        public long QualitativeId { get; set; }
        public long ResultsId { get; set; }
        public decimal? No3nppm { get; set; }
        public decimal? Ph { get; set; }
        public decimal? Csps { get; set; }
        public decimal? PsSieve1 { get; set; }
        public decimal? PsSieve2 { get; set; }
        public decimal? PsSieve3 { get; set; }
        public decimal? PsSieve4 { get; set; }
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

        public Results Results { get; set; }
    }
}
