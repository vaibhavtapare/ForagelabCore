using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Addresstype
    {
        public Addresstype()
        {
            Account = new HashSet<Account>();
        }

        public long AddressTypeId { get; set; }
        public string AddressTypeName { get; set; }
        public string AddressTypeDesc { get; set; }
        public string AddressTypeValue { get; set; }
        public DateTime? CreatedDt { get; set; }
        public string CreatedBy { get; set; }

        public ICollection<Account> Account { get; set; }
    }
}
