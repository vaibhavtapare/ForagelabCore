using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IFermentation
    {
        public long FermentationId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? Water { get; set; }
        public decimal? SampleWeight { get; set; }
        public decimal? Propanol1raw { get; set; }
        public decimal? MethanolRaw { get; set; }
        public decimal? EthanolRaw { get; set; }
        public decimal? Butanol2raw { get; set; }
        public decimal? MethylAcetateRaw { get; set; }
        public decimal? EthylAcetateRaw { get; set; }
        public decimal? PropylAcetateRaw { get; set; }
        public decimal? EthylLactateRaw { get; set; }
        public decimal? PropylLactateRaw { get; set; }
        public decimal? Propanol1calc { get; set; }
        public decimal? MethanolCalc { get; set; }
        public decimal? EthanolCalc { get; set; }
        public decimal? Butanol2calc { get; set; }
        public decimal? MethylAcetateCalc { get; set; }
        public decimal? EthylAcetateCalc { get; set; }
        public decimal? PropylAcetateCalc { get; set; }
        public decimal? EthylLactateCalc { get; set; }
        public decimal? PropylLactateCalc { get; set; }
        public bool? Release { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
