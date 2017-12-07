using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class FeedTypeAvgStdDev
    {
        public int FeedTypeAvgId { get; set; }
        public string FeedType { get; set; }
        public decimal? Avg30M120 { get; set; }
        public decimal? StdDev30M120 { get; set; }
        public decimal? AvgM120240 { get; set; }
        public decimal? StdDevM120240 { get; set; }
    }
}
