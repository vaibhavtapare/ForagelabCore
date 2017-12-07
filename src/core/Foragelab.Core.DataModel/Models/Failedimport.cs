using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Failedimport
    {
        public int Id { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
    }
}
