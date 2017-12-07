using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class TRangeFeedCodes
    {
        public int FeedCodeId { get; set; }
        public string FeedType { get; set; }
        public string FeedTypeSearch { get; set; }
        public int? FeedCode { get; set; }
        public string SampleDesc { get; set; }
        public bool? IsSampleDesc { get; set; }
        public string Condition { get; set; }
        public string SqlCondition { get; set; }
        public string SqlJoin { get; set; }
        public int? TableId { get; set; }
        public bool? IsRangeResult { get; set; }
    }
}
