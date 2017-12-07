using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Niroptions
    {
        public Niroptions()
        {
            MobSamplesubmissions = new HashSet<MobSamplesubmissions>();
        }

        public int NirOptionId { get; set; }
        public string NirOptionCode { get; set; }
        public string NirOptionName { get; set; }
        public string Description { get; set; }
        public decimal? DomesticPrice { get; set; }
        public decimal? InternationalPrice { get; set; }

        public ICollection<MobSamplesubmissions> MobSamplesubmissions { get; set; }
    }
}
