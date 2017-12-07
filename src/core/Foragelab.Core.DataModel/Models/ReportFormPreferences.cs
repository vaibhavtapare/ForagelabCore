using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportFormPreferences
    {
        public int PreferenceId { get; set; }
        public string ReportForm { get; set; }
        public string Description { get; set; }
        public int? DisplayOrder { get; set; }
        public bool? IsActive { get; set; }
    }
}
