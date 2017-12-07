using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SmCustomFields
    {
        public long Id { get; set; }
        public long? SamplesId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public long FieldId { get; set; }
        public long? LanguageId { get; set; }
        public string FieldContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
