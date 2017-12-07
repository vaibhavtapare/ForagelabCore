using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Userdetails
    {
        public long UserDetailsId { get; set; }
        public Guid? UserId { get; set; }
        public string AccountCode { get; set; }
        public string WinLabName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessName { get; set; }
        public string CopyTo { get; set; }
        public int? LanguageId { get; set; }
        public string ReportForm { get; set; }
        public string Fax { get; set; }
        public string FaxAnyTime { get; set; }
        public bool? IsCopyTo { get; set; }
        public long? AddressTypeId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Municipality { get; set; }
        public string City { get; set; }
        public int? RegionState { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public string Affilated { get; set; }
        public int? OfflineLimit { get; set; }
        public bool? Global { get; set; }

        public AspnetUsers User { get; set; }
    }
}
