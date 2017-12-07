using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportingColumns
    {
        public int CustomPreferenceColumnId { get; set; }
        public string ColumnName { get; set; }
        public int? ParentId { get; set; }
        public int? OrderBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
