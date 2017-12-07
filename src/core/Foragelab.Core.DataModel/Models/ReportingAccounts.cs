using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportingAccounts
    {
        public int Id { get; set; }
        public string AccountCode { get; set; }
        public int LanguageId { get; set; }

        public Languages Language { get; set; }
    }
}
