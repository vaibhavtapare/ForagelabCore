using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Statustype
    {
        public Statustype()
        {
            MobSampleentry = new HashSet<MobSampleentry>();
        }

        public int StatusTypeId { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }
        public string TypeValue { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }

        public ICollection<MobSampleentry> MobSampleentry { get; set; }
    }
}
