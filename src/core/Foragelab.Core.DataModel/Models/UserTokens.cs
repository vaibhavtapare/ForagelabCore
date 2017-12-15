using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class UserTokens
    {
        public long Id { get; set; }
        public long Userid { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? ResetExpiration { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
