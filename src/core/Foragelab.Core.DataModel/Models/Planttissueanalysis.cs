using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Planttissueanalysis
    {
        public int PlantTissueId { get; set; }
        public string PlantTissueCode { get; set; }
        public string PlantTissueValue { get; set; }
        public string PlantTissueDescription { get; set; }
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
