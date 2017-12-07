using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobFailedadssamples
    {
        public long FailSampleId { get; set; }
        public string SampleId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
    }
}
