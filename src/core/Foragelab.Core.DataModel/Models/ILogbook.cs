using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ILogbook
    {
        public long IlogbookId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public string Analysis { get; set; }
        public string ContactName { get; set; }
        public int? Country { get; set; }
        public string FeedType { get; set; }
        public string Initials { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Status { get; set; }
    }
}
