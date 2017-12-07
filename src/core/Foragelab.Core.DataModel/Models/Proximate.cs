using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Proximate
    {
        public int ProximateId { get; set; }
        public string ProximateCode { get; set; }
        public string ProximateValue { get; set; }
        public string ProximateDescription { get; set; }
        public decimal? DomesticPrice { get; set; }
        public decimal? InternationalPrice { get; set; }
        public int? OrderValue { get; set; }
        public bool? IsOption { get; set; }
        public bool? IsComponent { get; set; }
        public int? DomesticSpecialItemId { get; set; }
        public int? IntSpecialItemId { get; set; }

        public Specialitems DomesticSpecialItem { get; set; }
        public Specialitems IntSpecialItem { get; set; }
    }
}
