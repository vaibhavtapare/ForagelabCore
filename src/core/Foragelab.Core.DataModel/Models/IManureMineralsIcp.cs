using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IManureMineralsIcp
    {
        public long MineralsIcpid { get; set; }
        public long Imanure { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public decimal? Crucible { get; set; }
        public decimal? CrucibleplusSample { get; set; }
        public decimal? CrucibleplusDiluent { get; set; }
        public decimal? Factor { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IManure ImanureNavigation { get; set; }
    }
}
