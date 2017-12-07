using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Mycotoxins
    {
        public int MycotoxinId { get; set; }
        public string MycotoxinCode { get; set; }
        public string MycotoxinValue { get; set; }
        public string MycotoxinDescription { get; set; }
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
