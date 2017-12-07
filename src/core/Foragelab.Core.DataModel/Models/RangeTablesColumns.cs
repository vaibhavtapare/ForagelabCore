using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class RangeTablesColumns
    {
        public int ResultsTableColumnId { get; set; }
        public int? TableId { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDescription { get; set; }
        public bool? IsNutrient { get; set; }
        public bool? IsRangeResult { get; set; }
    }
}
