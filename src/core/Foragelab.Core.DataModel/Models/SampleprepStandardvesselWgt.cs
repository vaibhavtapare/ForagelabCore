using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SampleprepStandardvesselWgt
    {
        public SampleprepStandardvesselWgt()
        {
            SampleprepSamplesDm2Vessel = new HashSet<SampleprepSamples>();
            SampleprepSamplesDmVessel = new HashSet<SampleprepSamples>();
        }

        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int LocationId { get; set; }
        public string VesselId { get; set; }
        public decimal VesselWeight { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<SampleprepSamples> SampleprepSamplesDm2Vessel { get; set; }
        public ICollection<SampleprepSamples> SampleprepSamplesDmVessel { get; set; }
    }
}
