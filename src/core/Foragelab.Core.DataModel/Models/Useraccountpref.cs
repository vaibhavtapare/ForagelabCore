using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Useraccountpref
    {
        public long UserAccountPrefId { get; set; }
        public Guid? UserId { get; set; }
        public long? AccountPrefId { get; set; }

        public Accountpref AccountPref { get; set; }
        public AspnetUsers User { get; set; }
    }
}
