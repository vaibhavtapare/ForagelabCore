using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobPackagemappings
    {
        public int PackageMappingId { get; set; }
        public string PackageMasterName { get; set; }
        public string PackageName { get; set; }
        public string SpecialItemName { get; set; }
        public bool? IsInternational { get; set; }
        public bool? IsSpecialItem { get; set; }
        public bool? IsLcode { get; set; }
    }
}
