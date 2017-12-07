using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Address
    {
        public Address()
        {
            Accountaddress = new HashSet<Accountaddress>();
            Copyto = new HashSet<Copyto>();
        }

        public long AddressId { get; set; }
        public string AttnName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Municipality { get; set; }
        public string City { get; set; }
        public int? RegionState { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string CellPhone { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Accountaddress> Accountaddress { get; set; }
        public ICollection<Copyto> Copyto { get; set; }
    }
}
