using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Nirclass
    {
        public Nirclass()
        {
            MobSamplesubmissions = new HashSet<MobSamplesubmissions>();
        }

        public int NirClassId { get; set; }
        public string NirClassName { get; set; }
        public string NirClassNumber { get; set; }
        public string NirClassDescription { get; set; }
        public decimal? DomesticPrice { get; set; }
        public decimal? InternationalPrice { get; set; }
        public int? OrderValue { get; set; }

        public ICollection<MobSamplesubmissions> MobSamplesubmissions { get; set; }
    }
}
