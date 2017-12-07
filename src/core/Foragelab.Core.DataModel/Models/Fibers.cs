using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Fibers
    {
        public int FibersId { get; set; }
        public long ResultsId { get; set; }
        public decimal? SolFiber { get; set; }
        public decimal? Adf { get; set; }
        public decimal? Adfom { get; set; }
        public decimal? Ndf { get; set; }
        public decimal? ANdf { get; set; }
        public decimal? ANdfom { get; set; }
        public decimal? Ndr { get; set; }
        public decimal? ANdr { get; set; }
        public decimal? Ndrom { get; set; }
        public decimal? ANdrom { get; set; }
        public decimal? Cf { get; set; }
        public decimal? PeNdfNdf { get; set; }
        public decimal? Lignin { get; set; }
    }
}
