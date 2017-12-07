using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Emailsamplesdetails
    {
        public int SampleEmailId { get; set; }
        public Guid? SampleKey { get; set; }
        public Guid? UserId { get; set; }
        public string SampleFrom { get; set; }
        public string SampleTo { get; set; }
        public string SampleSubject { get; set; }
        public string SampleContent { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
