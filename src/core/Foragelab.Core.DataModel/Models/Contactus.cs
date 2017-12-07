using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Contactus
    {
        public int Id { get; set; }
        public string UserQuestion { get; set; }
        public string EmailId { get; set; }
        public bool? ShowLink { get; set; }
        public string ShowText { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedDt { get; set; }
        public int? UpdateBy { get; set; }
    }
}
