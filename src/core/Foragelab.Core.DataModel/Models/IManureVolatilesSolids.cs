﻿using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IManureVolatilesSolids
    {
        public long VolatilesSolidsId { get; set; }
        public long Imanure { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? AshedCrucible { get; set; }
        public decimal? Calculation { get; set; }
        public bool? Averaged { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IManure ImanureNavigation { get; set; }
    }
}
