using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SampleprepCylinder
    {
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int LocationId { get; set; }
        public string CylinderId { get; set; }
        public decimal CylinderWeight { get; set; }
        public bool? IsActive { get; set; }
    }
}
