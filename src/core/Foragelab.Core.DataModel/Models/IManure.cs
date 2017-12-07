using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IManure
    {
        public IManure()
        {
            IManureAmmonia = new HashSet<IManureAmmonia>();
            IManureCa = new HashSet<IManureCa>();
            IManureCl = new HashSet<IManureCl>();
            IManureCu = new HashSet<IManureCu>();
            IManureDensity = new HashSet<IManureDensity>();
            IManureFe = new HashSet<IManureFe>();
            IManureK = new HashSet<IManureK>();
            IManureMg = new HashSet<IManureMg>();
            IManureMineralsIcp = new HashSet<IManureMineralsIcp>();
            IManureMn = new HashSet<IManureMn>();
            IManureNa = new HashSet<IManureNa>();
            IManureNitrogen = new HashSet<IManureNitrogen>();
            IManureS = new HashSet<IManureS>();
            IManureTotalSolids = new HashSet<IManureTotalSolids>();
            IManureVolatilesSolids = new HashSet<IManureVolatilesSolids>();
            IManureWep = new HashSet<IManureWep>();
            IManureZn = new HashSet<IManureZn>();
            IManurep = new HashSet<IManurep>();
            IManurepH = new HashSet<IManurepH>();
        }

        public long ImanureId { get; set; }
        public decimal? Batch { get; set; }
        public decimal? Code { get; set; }
        public bool? Release { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public IManure Imanure { get; set; }
        public IManure InverseImanure { get; set; }
        public ICollection<IManureAmmonia> IManureAmmonia { get; set; }
        public ICollection<IManureCa> IManureCa { get; set; }
        public ICollection<IManureCl> IManureCl { get; set; }
        public ICollection<IManureCu> IManureCu { get; set; }
        public ICollection<IManureDensity> IManureDensity { get; set; }
        public ICollection<IManureFe> IManureFe { get; set; }
        public ICollection<IManureK> IManureK { get; set; }
        public ICollection<IManureMg> IManureMg { get; set; }
        public ICollection<IManureMineralsIcp> IManureMineralsIcp { get; set; }
        public ICollection<IManureMn> IManureMn { get; set; }
        public ICollection<IManureNa> IManureNa { get; set; }
        public ICollection<IManureNitrogen> IManureNitrogen { get; set; }
        public ICollection<IManureS> IManureS { get; set; }
        public ICollection<IManureTotalSolids> IManureTotalSolids { get; set; }
        public ICollection<IManureVolatilesSolids> IManureVolatilesSolids { get; set; }
        public ICollection<IManureWep> IManureWep { get; set; }
        public ICollection<IManureZn> IManureZn { get; set; }
        public ICollection<IManurep> IManurep { get; set; }
        public ICollection<IManurepH> IManurepH { get; set; }
    }
}
