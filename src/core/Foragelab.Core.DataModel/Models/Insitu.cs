using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Insitu
    {
        public int InsituId { get; set; }
        public string InsituCode { get; set; }
        public string InsituValue { get; set; }
        public string InsituDescription { get; set; }
        public decimal? DomesticPrice { get; set; }
        public decimal? InternationalPrice { get; set; }
        public bool? IsOption { get; set; }
        public bool? IsComponent { get; set; }
        public int? DomesticSpecialItemId { get; set; }
        public int? IntSpecialItemId { get; set; }

        public Specialitems DomesticSpecialItem { get; set; }
        public Specialitems IntSpecialItem { get; set; }
    }
}
