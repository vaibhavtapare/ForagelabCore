using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportingCustompreference
    {
        public ReportingCustompreference()
        {
            ReportingCustomPreferenceDetails = new HashSet<ReportingCustomPreferenceDetails>();
        }

        public long CustomPreferenceId { get; set; }
        public string ReportName { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsCopyTo { get; set; }

        public ReportingCustompreference CustomPreference { get; set; }
        public ReportingCustompreference InverseCustomPreference { get; set; }
        public ICollection<ReportingCustomPreferenceDetails> ReportingCustomPreferenceDetails { get; set; }
    }
}
