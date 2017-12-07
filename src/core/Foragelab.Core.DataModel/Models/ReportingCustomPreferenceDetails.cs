using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportingCustomPreferenceDetails
    {
        public long CustomPreferenceDetailsId { get; set; }
        public long CustomPreferenceId { get; set; }
        public int CustomPreferenceColumnId { get; set; }
        public int OrderBy { get; set; }

        public ReportingCustompreference CustomPreference { get; set; }
    }
}
