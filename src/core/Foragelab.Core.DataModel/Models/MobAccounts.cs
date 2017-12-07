using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobAccounts
    {
        public long AccountId { get; set; }
        public string AccountCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BusinessName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public bool IsAccount { get; set; }
        public bool IsCopyTo { get; set; }
        public DateTime? CreatedDt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
