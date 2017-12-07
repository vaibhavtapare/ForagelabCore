using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Useraccounts
    {
        public long UserAccountId { get; set; }
        public Guid UserId { get; set; }
        public long AccountId { get; set; }
    }
}
