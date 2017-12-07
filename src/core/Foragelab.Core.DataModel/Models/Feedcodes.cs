using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Feedcodes
    {
        public int FeedCodeId { get; set; }
        public int FeedCode { get; set; }
        public string FeedType { get; set; }
        public string GeneralClass { get; set; }
        public string Designator { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsQuickFeedType { get; set; }
    }
}
