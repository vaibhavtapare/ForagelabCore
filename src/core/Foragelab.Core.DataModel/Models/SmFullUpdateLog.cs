using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SmFullUpdateLog
    {
        public int Id { get; set; }
        public long? SamplesId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public int Version { get; set; }
        public string JsonData { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}
