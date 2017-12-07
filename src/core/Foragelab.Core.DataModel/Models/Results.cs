using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Results
    {
        public Results()
        {
            Dm = new HashSet<Dm>();
            Fermentation = new HashSet<Fermentation>();
            Microbial = new HashSet<Microbial>();
            Ndfd = new HashSet<Ndfd>();
            Qualitative = new HashSet<Qualitative>();
            Toxins = new HashSet<Toxins>();
            Water = new HashSet<Water>();
        }

        public long ResultsId { get; set; }
        public long? SamplesId { get; set; }
        public int? FermentationId { get; set; }
        public int? NirDataId { get; set; }
        public int? Choid { get; set; }
        public int? Dmid { get; set; }
        public int? Ivsdid { get; set; }
        public int? Ndfdid { get; set; }
        public int? FatId { get; set; }
        public int? MineralsId { get; set; }
        public int? ProteinsId { get; set; }
        public int? Ashid { get; set; }
        public int? FibersId { get; set; }
        public int? QualitativeId { get; set; }
        public int? AminoAcidsId { get; set; }
        public int? ToxinsId { get; set; }
        public int? MicrobialId { get; set; }
        public int? MicronId { get; set; }
        public int? CalculationId { get; set; }
        public int? MajorRevision { get; set; }
        public int? MinorRevision { get; set; }
        public string UserId { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? WaterId { get; set; }

        public ICollection<Dm> Dm { get; set; }
        public ICollection<Fermentation> Fermentation { get; set; }
        public ICollection<Microbial> Microbial { get; set; }
        public ICollection<Ndfd> Ndfd { get; set; }
        public ICollection<Qualitative> Qualitative { get; set; }
        public ICollection<Toxins> Toxins { get; set; }
        public ICollection<Water> Water { get; set; }
    }
}
