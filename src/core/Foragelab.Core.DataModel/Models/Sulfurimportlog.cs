using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Sulfurimportlog
    {
        public long SulfurImportId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? SFl { get; set; }
        public string TableName { get; set; }
        public string ActionName { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
