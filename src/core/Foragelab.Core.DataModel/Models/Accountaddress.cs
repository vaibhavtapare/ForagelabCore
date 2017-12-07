using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Accountaddress
    {
        public long AccountAddressId { get; set; }
        public long AddressId { get; set; }
        public long AccountId { get; set; }

        public Account Account { get; set; }
        public Address Address { get; set; }
    }
}
