using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IManureZn
    {
        public long ZnId { get; set; }
        public long Imanure { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? ValueImport { get; set; }
        public decimal? Calculation { get; set; }
        public bool? Averaged { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IManure ImanureNavigation { get; set; }
    }
}
