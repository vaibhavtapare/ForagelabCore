using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Microbial
    {
        public long MicrobialId { get; set; }
        public long ResultsId { get; set; }
        public decimal? Mold { get; set; }
        public decimal? Yeast { get; set; }
        public decimal? Fusarium { get; set; }
        public decimal? Aspergill { get; set; }
        public decimal? Penicill { get; set; }
        public decimal? Mucor { get; set; }
        public decimal? Thizopus { get; set; }
        public decimal? Cladospor { get; set; }
        public decimal? Absidia { get; set; }
        public decimal? Alternaria { get; set; }
        public decimal? Scopulariopsis { get; set; }
        public bool? NoColonies { get; set; }
        public bool? LmoldId { get; set; }

        public Results Results { get; set; }
    }
}
