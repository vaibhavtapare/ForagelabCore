using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Completedsamples
    {
        public long Id { get; set; }
        public string LabId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public short? NirClassId { get; set; }
        public short? ChemClassId { get; set; }
        public short? AgClassId { get; set; }
    }
}
