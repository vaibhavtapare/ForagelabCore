using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Toxins
    {
        public long ToxinsId { get; set; }
        public long ResultsId { get; set; }
        public decimal? Atox { get; set; }
        public decimal? Atoxb1 { get; set; }
        public decimal? Atoxb2 { get; set; }
        public decimal? Atoxg1 { get; set; }
        public decimal? Atoxg2 { get; set; }
        public decimal? Vtox { get; set; }
        public decimal? Don3ac { get; set; }
        public decimal? Don15ac { get; set; }
        public decimal? T2tox { get; set; }
        public decimal? Ztox { get; set; }
        public decimal? Ftoxb1 { get; set; }
        public decimal? Ftoxb2 { get; set; }
        public decimal? Ftoxb3 { get; set; }
        public decimal? Ochratoxin { get; set; }
        public decimal? Ht2 { get; set; }
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
        public bool? DonMethod { get; set; }
        public int ToxinLabId { get; set; }

        public Results Results { get; set; }
    }
}
