using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class CobrandReportExceptions
    {
        public int Id { get; set; }
        public int Cobrandid { get; set; }
        public string ExceptionName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }

        public CobrandReportExceptions IdNavigation { get; set; }
        public CobrandReportExceptions InverseIdNavigation { get; set; }
    }
}
