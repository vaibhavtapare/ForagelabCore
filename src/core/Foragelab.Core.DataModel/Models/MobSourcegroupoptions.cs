using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobSourcegroupoptions
    {
        public MobSourcegroupoptions()
        {
            SampleSourceGroup = new HashSet<SampleSourceGroup>();
        }

        public int SourceGroupOptionId { get; set; }
        public int? SourceGroupId { get; set; }
        public string SourceGroupOptionName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public Guid? ModifiedBy { get; set; }

        public ICollection<SampleSourceGroup> SampleSourceGroup { get; set; }
    }
}
