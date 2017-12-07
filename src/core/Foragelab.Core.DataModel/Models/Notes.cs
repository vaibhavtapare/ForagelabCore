using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Notes
    {
        public Notes()
        {
            Samplenotes = new HashSet<Samplenotes>();
        }

        public int NoteId { get; set; }
        public string Note { get; set; }

        public ICollection<Samplenotes> Samplenotes { get; set; }
    }
}
