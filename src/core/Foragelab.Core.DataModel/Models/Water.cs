using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Water
    {
        public long WaterId { get; set; }
        public long? ResultsId { get; set; }
        public string PH { get; set; }
        public string NitratesNitrogen { get; set; }
        public string Nitrates { get; set; }
        public string TotCol { get; set; }
        public string Ecoli { get; set; }
        public string CaCo3 { get; set; }
        public string Tds { get; set; }
        public string Chlorides { get; set; }
        public string SulfateSulfur { get; set; }
        public string Ca { get; set; }
        public string P { get; set; }
        public string Mg { get; set; }
        public string K { get; set; }
        public string Na { get; set; }
        public string Fe { get; set; }
        public string Mn { get; set; }
        public string Zinc { get; set; }
        public string Cu { get; set; }
        public string SulfSulf { get; set; }
        public string Alkalinity { get; set; }
        public string Mo { get; set; }
        public string Se { get; set; }
        public string Bo { get; set; }
        public string ReportFor { get; set; }
        public string CopyTo { get; set; }
        public string WaterSource { get; set; }

        public Results Results { get; set; }
    }
}
