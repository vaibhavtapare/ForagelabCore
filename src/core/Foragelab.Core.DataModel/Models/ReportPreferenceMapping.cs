using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportPreferenceMapping
    {
        public int ReportPrefMappingId { get; set; }
        public int ReportPrefId { get; set; }
        public string ColumnName { get; set; }
        public string ColumnTitle { get; set; }
    }
}
