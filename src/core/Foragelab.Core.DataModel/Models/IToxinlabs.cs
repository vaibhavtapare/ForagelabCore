using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IToxinlabs
    {
        public IToxinlabs()
        {
            IToxin = new HashSet<IToxin>();
        }

        public int Id { get; set; }
        public string LabName { get; set; }

        public ICollection<IToxin> IToxin { get; set; }
    }
}
