using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Account
    {
        public Account()
        {
            Accountaddress = new HashSet<Accountaddress>();
            Accountcopytos = new HashSet<Accountcopytos>();
            Linkedaccounts = new HashSet<Linkedaccounts>();
        }

        public long AccountId { get; set; }
        public string AccountCode { get; set; }
        public string WinLabName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessName { get; set; }
        public int? LanguageId { get; set; }
        public string ReportForm { get; set; }
        public string ReportPreference { get; set; }
        public string Fax { get; set; }
        public string FaxAnyTime { get; set; }
        public bool? IsCopyTo { get; set; }
        public long? AddressTypeId { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public string CopyTo { get; set; }
        public string AutoCopyTo { get; set; }
        public bool? IsMergeReports { get; set; }
        public int UnitSystemId { get; set; }

        public Addresstype AddressType { get; set; }
        public ICollection<Accountaddress> Accountaddress { get; set; }
        public ICollection<Accountcopytos> Accountcopytos { get; set; }
        public ICollection<Linkedaccounts> Linkedaccounts { get; set; }
    }
}
