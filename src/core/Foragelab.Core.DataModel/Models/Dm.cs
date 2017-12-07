using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Dm
    {
        public int Dmid { get; set; }
        public long ResultsId { get; set; }
        public decimal? Dm1 { get; set; }
        public decimal? Kfm { get; set; }
        public decimal? Moisture { get; set; }
        public decimal? DmRes { get; set; }

        public Results Results { get; set; }
    }
}
