using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Contentlabel
    {
        public int ContentLabelId { get; set; }
        public string ClpageName { get; set; }
        public string LableIdonPage { get; set; }
        public bool? IsMenu { get; set; }
        public int? FormatTypeId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
    }
}
