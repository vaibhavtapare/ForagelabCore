using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobSamplesubmissionsPackages
    {
        public long Id { get; set; }
        public long? SampleEntryId { get; set; }
        public int? PackageId { get; set; }
        public bool? IsInsitu { get; set; }
        public bool? IsProximate { get; set; }
        public bool? IsAnalysis { get; set; }
        public bool? IsComponent { get; set; }
        public bool? IsStarchDigestibility { get; set; }
        public bool? IsInvitro { get; set; }
        public bool? IsWetChemistry { get; set; }
        public bool? IsAminoAcid { get; set; }
        public bool? IsMycotoxin { get; set; }
        public bool? IsWater { get; set; }
        public bool? IsManure { get; set; }
        public bool? IsPlantTissue { get; set; }

        public MobSampleentry SampleEntry { get; set; }
    }
}
