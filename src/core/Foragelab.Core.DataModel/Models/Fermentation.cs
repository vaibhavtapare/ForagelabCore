using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Fermentation
    {
        public int FermentationId { get; set; }
        public long ResultsId { get; set; }
        public decimal? Acetic { get; set; }
        public decimal? Propionic { get; set; }
        public decimal? Butyric { get; set; }
        public decimal? Lactic { get; set; }
        public decimal? IsoValeric { get; set; }
        public decimal? Valeric { get; set; }
        public decimal? Caproic { get; set; }
        public decimal? IsoButyric { get; set; }
        public decimal? Propanediol12 { get; set; }
        public decimal? Propanol1 { get; set; }
        public decimal? Methanol { get; set; }
        public decimal? Ethanol { get; set; }
        public decimal? Butanol2 { get; set; }
        public decimal? MethylAcetate { get; set; }
        public decimal? EthylAcetate { get; set; }
        public decimal? PropylAcetate { get; set; }
        public decimal? EthylLactate { get; set; }
        public decimal? PropylLactate { get; set; }
        public decimal? TotVfa { get; set; }
        public decimal? TitAc { get; set; }

        public Results Results { get; set; }
    }
}
