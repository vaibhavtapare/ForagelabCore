using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class TagProducts
    {
        public long TagProductId { get; set; }
        public string TagProduct { get; set; }
        public string TagMemo { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDt { get; set; }
    }
}
