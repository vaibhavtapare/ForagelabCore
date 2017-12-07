﻿using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class AspnetPersonalizationPerUser
    {
        public Guid Id { get; set; }
        public Guid? PathId { get; set; }
        public Guid? UserId { get; set; }
        public byte[] PageSettings { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public AspnetPaths Path { get; set; }
        public AspnetUsers User { get; set; }
    }
}
