using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Contentlabelml
    {
        public int ContentLabelMlid { get; set; }
        public int? ContentLabelId { get; set; }
        public int LanguageId { get; set; }
        public string ContentLabel { get; set; }
        public bool? IsAdminArea { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
