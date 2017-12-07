using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Billitems
    {
        public long BillItemId { get; set; }
        public int? SpecialItemId { get; set; }
        public long? SamplesId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public Samples Samples { get; set; }
        public Specialitems SpecialItem { get; set; }
    }
}
