using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobSampleentry
    {
        public MobSampleentry()
        {
            MobSampleAccountMapping = new HashSet<MobSampleAccountMapping>();
            MobSamplesubmissions = new HashSet<MobSamplesubmissions>();
            MobSamplesubmissionsPackages = new HashSet<MobSamplesubmissionsPackages>();
            Sampleaditionalinformation = new HashSet<Sampleaditionalinformation>();
        }

        public long SampleEntryId { get; set; }
        public long? BillToAccountCode { get; set; }
        public long? CopyToAccountCode1 { get; set; }
        public long? CopyToAccountCode2 { get; set; }
        public long? CopyToAccountCode3 { get; set; }
        public long? CopyToAccountCode4 { get; set; }
        public string LabNo { get; set; }
        public string SequentialNo { get; set; }
        public string FarmName { get; set; }
        public string SampleDesc { get; set; }
        public string Cutting { get; set; }
        public string AmountofSample { get; set; }
        public int? Year { get; set; }
        public string EstimatedDryMatter { get; set; }
        public string UserMemo { get; set; }
        public string FeedName { get; set; }
        public int? StatusTypeId { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? SampledDate { get; set; }
        public DateTime? CollectedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime? CreatedDt { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public Guid? UserId { get; set; }
        public string CopyTo1Report { get; set; }
        public string CopyTo2Report { get; set; }
        public string CopyTo3Report { get; set; }
        public string CopyTo4Report { get; set; }
        public string SampleId { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? AdditionalFee { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public string Notes { get; set; }
        public int? FeedCodeId { get; set; }
        public int? StorageSystemId { get; set; }
        public string Treatment { get; set; }
        public string Processing { get; set; }
        public int? ReceivingConditionsId { get; set; }
        public string GrindSize { get; set; }
        public bool? Wet { get; set; }
        public bool? Processed { get; set; }
        public bool? Preground { get; set; }
        public string ShippingTracker { get; set; }
        public int? SourceGroupId { get; set; }
        public int? SourceGroupOptionId { get; set; }
        public bool? Adssubmission { get; set; }

        public Statustype StatusType { get; set; }
        public ICollection<MobSampleAccountMapping> MobSampleAccountMapping { get; set; }
        public ICollection<MobSamplesubmissions> MobSamplesubmissions { get; set; }
        public ICollection<MobSamplesubmissionsPackages> MobSamplesubmissionsPackages { get; set; }
        public ICollection<Sampleaditionalinformation> Sampleaditionalinformation { get; set; }
    }
}
