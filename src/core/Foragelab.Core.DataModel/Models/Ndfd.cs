using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Ndfd
    {
        public long Ndfdid { get; set; }
        public long ResultsId { get; set; }
        public decimal? NdfdIv12 { get; set; }
        public decimal? NdfdIv24 { get; set; }
        public decimal? NdfdIv30 { get; set; }
        public decimal? NdfdIv48 { get; set; }
        public decimal? INdf { get; set; }
        public decimal? Dmd2 { get; set; }
        public decimal? NutrecoPd { get; set; }
        public decimal? NutrecoIf { get; set; }
        public decimal? NdfdIv2 { get; set; }
        public decimal? NdfdIv4 { get; set; }
        public decimal? NdfdIv6 { get; set; }
        public decimal? NdfdIv8 { get; set; }
        public decimal? NdfdIv18 { get; set; }
        public decimal? NdfdIv72 { get; set; }
        public decimal? NdfdIv96 { get; set; }
        public decimal? NdfdIv120 { get; set; }
        public decimal? NdfdIv240 { get; set; }
        public decimal? NdfdIv246 { get; set; }
        public decimal? NdfdIv306 { get; set; }
        public decimal? NdfdIv2406 { get; set; }

        public Results Results { get; set; }
    }
}
