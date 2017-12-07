using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Linkedaccounts
    {
        public long LinkedAccountId { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsMaster { get; set; }
        public long? AccountId { get; set; }

        public Account Account { get; set; }
        public AspnetUsers User { get; set; }
    }
}
