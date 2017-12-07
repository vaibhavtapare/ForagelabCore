using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class INirdata
    {
        public long InirDataId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
