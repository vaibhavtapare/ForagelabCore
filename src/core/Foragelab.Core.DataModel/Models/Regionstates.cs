using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Regionstates
    {
        public int RegionStateId { get; set; }
        public int? RegionsId { get; set; }
        public string RegionsStateName { get; set; }
        public string RegionsStateDescription { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
    }
}
