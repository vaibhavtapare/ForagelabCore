using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobAccountusers
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public Guid UserId { get; set; }
        public bool? IsMobileAccount { get; set; }
    }
}
