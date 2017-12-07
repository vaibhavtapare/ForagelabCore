using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class RationUseraccess
    {
        public long Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime LastAccess { get; set; }
        public string MethodName { get; set; }

        public AspnetUsers User { get; set; }
    }
}
