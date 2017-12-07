using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IPdi
    {
        public long Pdiid { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? Dm { get; set; }
        public decimal? Moisture { get; set; }
        public decimal? CrudeProteinDry { get; set; }
        public decimal? CrudeProteinAsIs { get; set; }
        public decimal? ProteinDispersibilityIndex { get; set; }
        public decimal? UreaseActivity { get; set; }
        public bool? Release { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
