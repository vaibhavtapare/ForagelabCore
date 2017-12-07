using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Components
    {
        public int ComponentId { get; set; }
        public string ComponentCode { get; set; }
        public string ComponentValue { get; set; }
        public string ComponentDescription { get; set; }
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
