using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Languages
    {
        public Languages()
        {
            ReportingAccounts = new HashSet<ReportingAccounts>();
        }

        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string LanguageDesc { get; set; }
        public bool? IsDeleted { get; set; }
        public string LanguageUrl { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<ReportingAccounts> ReportingAccounts { get; set; }
    }
}
