using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Nirequations
    {
        public Nirequations()
        {
            SampleprepSamples = new HashSet<SampleprepSamples>();
        }

        public int NirequationId { get; set; }
        public string Equation { get; set; }
        public string ShortCode { get; set; }

        public ICollection<SampleprepSamples> SampleprepSamples { get; set; }
    }
}
