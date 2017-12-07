using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Sampleaditionalinformation
    {
        public long SampleAditionalInformationId { get; set; }
        public long SampleEntryId { get; set; }
        public string SourceName { get; set; }
        public string SourceLocation { get; set; }
        public string CuttingInterval { get; set; }
        public string LotSize { get; set; }
        public string AmountReceived { get; set; }
        public string SampleCondition { get; set; }
        public string ApprovedBy { get; set; }
        public string SamplerName { get; set; }
        public bool? Certified { get; set; }
        public bool? CertifiedProtocol { get; set; }
        public string SampleingDevice { get; set; }
        public string NoOfCoresAndBales { get; set; }
        public string SampleGround { get; set; }
        public string SpilitingMethod { get; set; }
        public string GrinderUsed { get; set; }
        public string GrinderType { get; set; }
        public string ScreenSize { get; set; }
        public string GrindingTechnician { get; set; }
        public string Po { get; set; }
        public string ProjectId { get; set; }
        public DateTime? PlantingDate { get; set; }
        public string StorageWeeks { get; set; }
        public decimal? Postage { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDt { get; set; }

        public MobSampleentry SampleEntry { get; set; }
    }
}
