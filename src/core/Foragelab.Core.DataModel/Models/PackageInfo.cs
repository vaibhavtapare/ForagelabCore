using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class PackageInfo
    {
        public int IdColumn { get; set; }
        public int? SequenceNo { get; set; }
        public string PackageName { get; set; }
        public int? NirClassId { get; set; }
        public int? ChemClassId { get; set; }
        public int? AgClassId { get; set; }
    }
}
