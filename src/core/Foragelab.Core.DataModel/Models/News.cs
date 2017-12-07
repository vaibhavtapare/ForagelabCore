using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class News
    {
        public News()
        {
            Newsmedia = new HashSet<Newsmedia>();
        }

        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string Description { get; set; }
        public int LanguageId { get; set; }
        public int? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? ModifedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public AspnetUsers CreatedByNavigation { get; set; }
        public AspnetUsers ModifedByNavigation { get; set; }
        public ICollection<Newsmedia> Newsmedia { get; set; }
    }
}
