using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobCopytousers
    {
        public long MobCopyToUserId { get; set; }
        public long CopyToId { get; set; }
        public Guid? UserId { get; set; }
        public bool? IsMobileCopyTo { get; set; }
    }
}
