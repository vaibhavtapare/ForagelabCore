using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Proteins
    {
        public int ProteinsId { get; set; }
        public long ResultsId { get; set; }
        public decimal? Cp { get; set; }
        public decimal? Sp { get; set; }
        public decimal? Adicp { get; set; }
        public decimal? Ndicp { get; set; }
        public decimal? Nh3cpe { get; set; }
    }
}
