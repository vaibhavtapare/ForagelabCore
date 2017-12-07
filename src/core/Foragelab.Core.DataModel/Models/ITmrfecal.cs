using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ITmrfecal
    {
        public long TmrFecalId { get; set; }
        public long? TmrSamplesId { get; set; }
        public long? FecalSamplesId { get; set; }
        public bool? Release { get; set; }
        public bool? TmrFecalSamplePair { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public Samples FecalSamples { get; set; }
        public Samples TmrSamples { get; set; }
    }
}
