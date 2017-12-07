using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobSourceharvests
    {
        public int SourceHarvestId { get; set; }
        public int? SourceGroupId { get; set; }
        public DateTime? SourceHarvestDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public Guid? ModifiedBy { get; set; }

        public MobSourcegroups SourceGroup { get; set; }
    }
}
