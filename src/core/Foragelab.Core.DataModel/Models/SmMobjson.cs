using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SmMobjson
    {
        public long Id { get; set; }
        public decimal Code { get; set; }
        public decimal Batch { get; set; }
        public string Jsondata { get; set; }
    }
}
