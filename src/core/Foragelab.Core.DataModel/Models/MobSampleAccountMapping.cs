using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobSampleAccountMapping
    {
        public int MobSampleAccountMappingId { get; set; }
        public long AccountId { get; set; }
        public long SampleEntryId { get; set; }
        public string AccountCode { get; set; }

        public MobSampleentry SampleEntry { get; set; }
    }
}
