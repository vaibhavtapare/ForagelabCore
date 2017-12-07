using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class TRangeResult
    {
        public int Id { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public int? DmLow { get; set; }
        public int? DmHigh { get; set; }
        public decimal? ColAvg { get; set; }
        public decimal? ColMin { get; set; }
        public decimal? ColMax { get; set; }
        public decimal? ColStd { get; set; }
        public decimal? ColBottom { get; set; }
        public decimal? ColTop { get; set; }
        public string SampleDesc { get; set; }
        public int? FeedCode { get; set; }
        public string FeedType { get; set; }
        public string Designator { get; set; }
        public decimal? Std2 { get; set; }
        public long? SampleCount { get; set; }
        public string SqlCondition { get; set; }
        public string SqlJoin { get; set; }
    }
}
