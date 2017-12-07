using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class INdfdinvitro
    {
        public long IndfdInvitroId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public long? SampleId { get; set; }
        public int? TimePointId { get; set; }
        public decimal? INdfndf { get; set; }
        public decimal? DNdfndf { get; set; }
        public bool? Averaged { get; set; }
        public decimal? Sampleweight { get; set; }
        public decimal? FilterWeight { get; set; }
        public decimal? FilterAshWeight { get; set; }
        public decimal? FinalWeight { get; set; }
        public decimal? CorrectionFactor { get; set; }
        public decimal? Blank { get; set; }
        public int? RunNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public decimal? INdfomNdf { get; set; }
        public decimal? DNdfomNdf { get; set; }
        public decimal? INdfdm { get; set; }
        public decimal? DNdfdm { get; set; }
        public decimal? INdfomDm { get; set; }
        public decimal? DNdfomDm { get; set; }
        public bool? AndFom { get; set; }
        public bool? IsInInvitro { get; set; }

        public Samples Sample { get; set; }
        public ITimePoint TimePoint { get; set; }
    }
}
