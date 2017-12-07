using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobSamplebags
    {
        public int BagId { get; set; }
        public string BagNumber { get; set; }
        public string BagBarcodeNumber { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }

        public AspnetUsers CreatedByNavigation { get; set; }
    }
}
