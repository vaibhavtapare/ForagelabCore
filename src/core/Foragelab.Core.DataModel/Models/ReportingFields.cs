using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportingFields
    {
        public ReportingFields()
        {
            ReportingLingualFields = new HashSet<ReportingLingualFields>();
        }

        public int FieldId { get; set; }
        public string KeyName { get; set; }

        public ICollection<ReportingLingualFields> ReportingLingualFields { get; set; }
    }
}
