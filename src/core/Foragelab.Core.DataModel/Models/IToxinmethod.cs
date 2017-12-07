using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IToxinmethod
    {
        public long ItoxinMethodId { get; set; }
        public long ItoxinId { get; set; }
        public bool? DonMethod { get; set; }

        public IToxin Itoxin { get; set; }
    }
}
