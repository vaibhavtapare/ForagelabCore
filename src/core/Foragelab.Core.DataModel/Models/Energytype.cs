using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Energytype
    {
        public int EqTypeId { get; set; }
        public string EqTypeCode { get; set; }
        public bool? IsActive { get; set; }
        public string EqTypeDescription { get; set; }
    }
}
