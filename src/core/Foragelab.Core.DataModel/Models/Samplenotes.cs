using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Samplenotes
    {
        public int Id { get; set; }
        public long SampleId { get; set; }
        public int NoteId { get; set; }
        public bool? IsWater { get; set; }

        public Notes Note { get; set; }
        public Samples Sample { get; set; }
    }
}
