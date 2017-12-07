using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobSamplesubmissions
    {
        public int Id { get; set; }
        public long? SampleEntryId { get; set; }
        public int? NirClassId { get; set; }
        public int? NirOptionId { get; set; }
        public int? WetChemistryId { get; set; }

        public Nirclass NirClass { get; set; }
        public Niroptions NirOption { get; set; }
        public MobSampleentry SampleEntry { get; set; }
        public Wetchemistry WetChemistry { get; set; }
    }
}
