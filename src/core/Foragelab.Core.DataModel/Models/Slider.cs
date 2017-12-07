using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Slider
    {
        public int SliderId { get; set; }
        public int? LanguageId { get; set; }
        public string SliderTitle { get; set; }
        public string SliderLink { get; set; }
        public int? SliderOrder { get; set; }
        public string ImageName { get; set; }
        public int? MediaId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
