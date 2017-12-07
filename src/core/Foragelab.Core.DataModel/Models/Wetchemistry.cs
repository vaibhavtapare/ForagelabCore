using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Wetchemistry
    {
        public Wetchemistry()
        {
            MobSamplesubmissions = new HashSet<MobSamplesubmissions>();
        }

        public int WetChemistryId { get; set; }
        public string WetChemistryCode { get; set; }
        public string WetChemistryValue { get; set; }
        public string WetChemistryDescription { get; set; }
        public decimal? DomesticPrice { get; set; }
        public decimal? InternationalPrice { get; set; }
        public int? OrderValue { get; set; }
        public bool? IsOption { get; set; }
        public bool? IsComponent { get; set; }

        public ICollection<MobSamplesubmissions> MobSamplesubmissions { get; set; }
    }
}
