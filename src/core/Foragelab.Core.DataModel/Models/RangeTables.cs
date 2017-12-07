using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class RangeTables
    {
        public int TableId { get; set; }
        public string TableName { get; set; }
        public string TableDescription { get; set; }
        public string TablePrimaryKey { get; set; }
        public bool? IsNutrient { get; set; }
        public bool? IsRangeResult { get; set; }
    }
}
