using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IMoldIdentificationDetails
    {
        public long MoldIdentificationDetailsId { get; set; }
        public long MoldIdentificationId { get; set; }
        public int MoldId { get; set; }
        public int? MoldPercentage { get; set; }

        public IMoldsMaster Mold { get; set; }
        public IMoldIdentification MoldIdentification { get; set; }
    }
}
