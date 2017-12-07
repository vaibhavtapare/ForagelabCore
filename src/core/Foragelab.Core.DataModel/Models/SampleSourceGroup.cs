using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SampleSourceGroup
    {
        public long SampleSourceGroupId { get; set; }
        public long? SampleId { get; set; }
        public int? SourceGroupId { get; set; }
        public int? SourceGroupOptionId { get; set; }

        public MobSourcegroups SourceGroup { get; set; }
        public MobSourcegroupoptions SourceGroupOption { get; set; }
    }
}
