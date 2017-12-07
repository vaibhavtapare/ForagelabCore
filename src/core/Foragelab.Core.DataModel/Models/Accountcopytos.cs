using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Accountcopytos
    {
        public long AccountCopyToId { get; set; }
        public long AccountId { get; set; }
        public long CopyToId { get; set; }

        public Account Account { get; set; }
        public Copyto CopyTo { get; set; }
    }
}
