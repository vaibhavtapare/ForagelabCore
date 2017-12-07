using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Rupreport
    {
        public int RupreportId { get; set; }
        public long SamplesId { get; set; }
        public decimal DryMatter { get; set; }
        public decimal ProteinDmbasis { get; set; }
        public decimal ProteinAsRecieved { get; set; }
        public decimal SpCp { get; set; }
        public decimal SpDm { get; set; }
        public decimal AmmoniaCp { get; set; }
        public decimal AmmoniaDm { get; set; }
        public decimal RuDpCp { get; set; }
        public decimal RuDpDm { get; set; }
        public decimal RdpCp { get; set; }
        public decimal RdpDm { get; set; }
        public decimal IdpCp { get; set; }
        public decimal IdpDm { get; set; }
        public decimal TotalTractDpCp { get; set; }
        public decimal TotalTractDpDm { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
