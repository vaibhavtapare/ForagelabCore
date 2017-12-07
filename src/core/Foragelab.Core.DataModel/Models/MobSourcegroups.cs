using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobSourcegroups
    {
        public MobSourcegroups()
        {
            MobSourceharvests = new HashSet<MobSourceharvests>();
            SampleSourceGroup = new HashSet<SampleSourceGroup>();
        }

        public int SourceGroupId { get; set; }
        public Guid? UserId { get; set; }
        public string SourceGroupName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public Guid? ModifiedBy { get; set; }

        public ICollection<MobSourceharvests> MobSourceharvests { get; set; }
        public ICollection<SampleSourceGroup> SampleSourceGroup { get; set; }
    }
}
