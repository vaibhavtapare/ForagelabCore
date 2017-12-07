using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class TempCompletedsamples
    {
        public long Id { get; set; }
        public string LabId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public short? NirclassId { get; set; }
        public short? ChemClassId { get; set; }
        public short? Agclass { get; set; }
    }
}
