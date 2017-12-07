using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Srctype
    {
        public int SrcTypeId { get; set; }
        public string Cname { get; set; }
        public string Cvalue { get; set; }
        public bool? IsActive { get; set; }
    }
}
