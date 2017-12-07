using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SatelliteChemLog
    {
        public int SatelliteChemLogId { get; set; }
        public int SamplesId { get; set; }
        public bool? PreGround { get; set; }
        public string Notes { get; set; }
    }
}
