using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Cmspageml
    {
        public Cmspageml()
        {
            Cmsmedia = new HashSet<Cmsmedia>();
        }

        public long CmspageMlid { get; set; }
        public int LanguageId { get; set; }
        public int? MenulinkId { get; set; }
        public long? ParentId { get; set; }
        public string CmspageTitle { get; set; }
        public string CmspageDescription { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public Menu Menulink { get; set; }
        public ICollection<Cmsmedia> Cmsmedia { get; set; }
    }
}
