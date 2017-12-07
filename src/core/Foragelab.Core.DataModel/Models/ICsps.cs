using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ICsps
    {
        public long Cspsid { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? SampleStarch { get; set; }
        public decimal? NirstarchCoarse { get; set; }
        public decimal? PanWeight { get; set; }
        public decimal? Coarse { get; set; }
        public decimal? Medium { get; set; }
        public decimal? Fine { get; set; }
        public decimal? CoarsePercentage { get; set; }
        public decimal? MediumPercentage { get; set; }
        public decimal? FinePercentage { get; set; }
        public decimal? Csps { get; set; }
        public bool? Release { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
