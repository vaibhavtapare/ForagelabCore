using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IMoldIdentification
    {
        public IMoldIdentification()
        {
            IMoldIdentificationDetails = new HashSet<IMoldIdentificationDetails>();
        }

        public long MoldIdentificationId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public bool? Release { get; set; }
        public bool? NoColonies { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public ICollection<IMoldIdentificationDetails> IMoldIdentificationDetails { get; set; }
    }
}
