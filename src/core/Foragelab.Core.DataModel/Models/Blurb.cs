using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Blurb
    {
        public int BlurbId { get; set; }
        public int? LanguageId { get; set; }
        public string BlurbTitle { get; set; }
        public string BlurbText { get; set; }
        public int? BlurbOrder { get; set; }
        public string ImageName { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public int? ParentId { get; set; }
        public DateTime? CreatedDt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
