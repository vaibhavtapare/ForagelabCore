using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IMoldsMaster
    {
        public IMoldsMaster()
        {
            IMoldIdentificationDetails = new HashSet<IMoldIdentificationDetails>();
        }

        public int MoldId { get; set; }
        public string Mold { get; set; }

        public ICollection<IMoldIdentificationDetails> IMoldIdentificationDetails { get; set; }
    }
}
