using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Memodetails
    {
        public int MemoId { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
