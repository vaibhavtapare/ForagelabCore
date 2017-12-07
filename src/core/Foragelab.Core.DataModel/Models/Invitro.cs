using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Invitro
    {
        public long NdfdIv240id { get; set; }
        public long Sampleid { get; set; }
        public int Timepoint { get; set; }
        public decimal? Value { get; set; }

        public Samples Sample { get; set; }
    }
}
