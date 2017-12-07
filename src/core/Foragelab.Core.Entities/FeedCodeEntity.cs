using System;
using System.Collections.Generic;
using System.Text;

namespace Foragelab.Core.Entities
{
    public class FeedCodeEntity
    {
        public int FeedCodeId { get; set; }
        public int FeedCode { get; set; }
        public string FeedType { get; set; }
        public string GeneralClass { get; set; }
        public string Designator { get; set; }
        public bool IsQuickFeedType { get; set; }
    }
}
