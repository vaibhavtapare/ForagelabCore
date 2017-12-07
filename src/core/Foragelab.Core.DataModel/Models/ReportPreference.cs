using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportPreference
    {
        public int ReportPrefId { get; set; }
        public string ReportName { get; set; }
        public Guid? UserId { get; set; }
        public string Columns { get; set; }
    }
}
