using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Copyto
    {
        public Copyto()
        {
            Accountcopytos = new HashSet<Accountcopytos>();
        }

        public long CopyToId { get; set; }
        public string AccountCode { get; set; }
        public string WinLabName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string BuisnessName { get; set; }
        public int? LanguageId { get; set; }
        public string ReportForm { get; set; }
        public string ReportPreference { get; set; }
        public string Fax { get; set; }
        public string FaxAnytime { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public Guid? ModifiedBy { get; set; }
        public long? AddressId { get; set; }
        public string CopyToName { get; set; }
        public bool? IsMergeReports { get; set; }

        public Address Address { get; set; }
        public ICollection<Accountcopytos> Accountcopytos { get; set; }
    }
}
