using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class INdfddata
    {
        public long IndfdDataId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public bool? Release { get; set; }
        public decimal? NdfBag { get; set; }
        public decimal? NdfBagTr { get; set; }
        public decimal? NdfBagSm { get; set; }
        public decimal? Ndf2Bag { get; set; }
        public decimal? Ndf2BagTr { get; set; }
        public decimal? Ndf2BagSm { get; set; }
        public decimal? Ndf3Bag { get; set; }
        public decimal? Ndf3BagTr { get; set; }
        public decimal? Ndf3BagSm { get; set; }
        public decimal? NdfdResult1 { get; set; }
        public decimal? NdfdResult2 { get; set; }
        public decimal? NdfdResult3 { get; set; }
        public decimal? Lag { get; set; }
        public bool? ANdf { get; set; }
        public bool? ANdfom { get; set; }
        public bool? ANdr { get; set; }
        public bool? ANdrom { get; set; }
        public decimal? FilterPlusAsh1 { get; set; }
        public decimal? FilterPlusAsh2 { get; set; }
        public decimal? FilterPlusAsh3 { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
