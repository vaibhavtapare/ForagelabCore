using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IManureS
    {
        public long Sid { get; set; }
        public long Imanure { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? ValueImport { get; set; }
        public bool? Averaged { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IManure ImanureNavigation { get; set; }
    }
}
