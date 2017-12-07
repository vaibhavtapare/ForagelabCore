using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Affiliatelabs
    {
        public int AffiliateId { get; set; }
        public string AffiliateCode { get; set; }
        public bool? IsActive { get; set; }
        public int? Frequency { get; set; }
    }
}
