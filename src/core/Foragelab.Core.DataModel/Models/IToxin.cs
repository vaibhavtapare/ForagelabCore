using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IToxin
    {
        public IToxin()
        {
            IToxinmethod = new HashSet<IToxinmethod>();
            IToxinnondetect = new HashSet<IToxinnondetect>();
        }

        public long ItoxinId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public bool? Release { get; set; }
        public int ToxinLabId { get; set; }
        public decimal? Atoxb1 { get; set; }
        public decimal? Atoxb2 { get; set; }
        public decimal? Atoxg1 { get; set; }
        public decimal? Atoxg2 { get; set; }
        public decimal? Ochratoxin { get; set; }
        public decimal? Ztox { get; set; }
        public decimal? Don { get; set; }
        public decimal? Don15ac { get; set; }
        public decimal? Don3ac { get; set; }
        public decimal? T2tox { get; set; }
        public decimal? Ht2 { get; set; }
        public decimal? Ftoxb1 { get; set; }
        public decimal? Ftoxb2 { get; set; }
        public decimal? Ftoxb3 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IToxinlabs ToxinLab { get; set; }
        public ICollection<IToxinmethod> IToxinmethod { get; set; }
        public ICollection<IToxinnondetect> IToxinnondetect { get; set; }
    }
}
