using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SampleprepPan
    {
        public long Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int LocationId { get; set; }
        public string PanId { get; set; }
        public decimal PanWeight { get; set; }
        public bool? IsActive { get; set; }
    }
}
