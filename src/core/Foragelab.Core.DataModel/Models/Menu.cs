using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Menu
    {
        public Menu()
        {
            Cmspageml = new HashSet<Cmspageml>();
        }

        public int MenulinkId { get; set; }
        public int LanguageId { get; set; }
        public int? ParentId { get; set; }
        public string MenuName { get; set; }
        public string LinkPath { get; set; }
        public int? DisplayOrder { get; set; }
        public int? ParentMenu { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public Menu Menulink { get; set; }
        public Menu InverseMenulink { get; set; }
        public ICollection<Cmspageml> Cmspageml { get; set; }
    }
}
