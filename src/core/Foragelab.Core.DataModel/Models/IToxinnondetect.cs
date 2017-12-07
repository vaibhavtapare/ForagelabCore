using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IToxinnondetect
    {
        public long ItoxinIdnonDetect { get; set; }
        public long ItoxinId { get; set; }
        public bool? Atoxb1NonDetect { get; set; }
        public bool? Atoxb2NonDetect { get; set; }
        public bool? Atoxg1NonDetect { get; set; }
        public bool? Atoxg2NonDetect { get; set; }
        public bool? OchratoxinNonDetect { get; set; }
        public bool? ZtoxNonDetect { get; set; }
        public bool? DonNonDetect { get; set; }
        public bool? Don15acNonDetect { get; set; }
        public bool? Don3acNonDetect { get; set; }
        public bool? T2toxNonDetect { get; set; }
        public bool? Ht2NonDetect { get; set; }
        public bool? Ftoxb1NonDetect { get; set; }
        public bool? Ftoxb2NonDetect { get; set; }
        public bool? Ftoxb3NonDetect { get; set; }

        public IToxin Itoxin { get; set; }
    }
}
