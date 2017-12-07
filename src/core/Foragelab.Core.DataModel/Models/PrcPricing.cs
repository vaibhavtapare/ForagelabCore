using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class PrcPricing
    {
        public int PricingId { get; set; }
        public int? TestTypeId { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public string PackageDetail { get; set; }
        public decimal? DomesticPrice { get; set; }
        public decimal? InternationPrice { get; set; }
        public int? PackageOrder { get; set; }
        public bool? IsInternational { get; set; }
        public bool? IsActive { get; set; }
    }
}
