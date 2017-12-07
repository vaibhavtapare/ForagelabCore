using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Fertilization
    {
        public int FertilizationId { get; set; }
        public string Cname { get; set; }
        public string Cvalue { get; set; }
        public bool? IsActive { get; set; }
    }
}
