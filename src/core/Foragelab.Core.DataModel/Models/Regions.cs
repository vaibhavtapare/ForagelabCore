using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Regions
    {
        public int RegionsId { get; set; }
        public string RegionsName { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
    }
}
