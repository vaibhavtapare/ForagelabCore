using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ValDmRawdataTemp
    {
        public long DmRawTempid { get; set; }
        public decimal Batch { get; set; }
        public decimal Code { get; set; }
        public decimal? StdDev { get; set; }
        public decimal? HygroChem { get; set; }
        public decimal? HygroNir { get; set; }
        public decimal? DmDry { get; set; }
        public decimal? DmPan { get; set; }
        public decimal? DmPansm { get; set; }
        public decimal? Dm2Dry { get; set; }
        public decimal? Dm2Pan { get; set; }
        public decimal? Dm2Pansm { get; set; }
        public decimal? Dm3Dry { get; set; }
        public decimal? Dm3Pan { get; set; }
        public decimal? Dm3Pansm { get; set; }
    }
}
