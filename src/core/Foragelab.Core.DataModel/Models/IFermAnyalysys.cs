using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IFermAnyalysys
    {
        public int AnyalysysId { get; set; }
        public string SampleType { get; set; }
        public string SampleDescription { get; set; }
        public string ColumnName { get; set; }
        public decimal? Average { get; set; }
        public int? NumberOfSamples { get; set; }
        public string Range { get; set; }
        public string DmRange { get; set; }
        public decimal? DmMin { get; set; }
        public decimal? DmMax { get; set; }
    }
}
