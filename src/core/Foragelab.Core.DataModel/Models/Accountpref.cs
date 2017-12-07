using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Accountpref
    {
        public Accountpref()
        {
            Useraccountpref = new HashSet<Useraccountpref>();
        }

        public long AccountPrefId { get; set; }
        public string AccountPrefName { get; set; }
        public string AccountPrefDescription { get; set; }
        public string AccountPrefSwitch { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public int? ModifiedBy { get; set; }

        public ICollection<Useraccountpref> Useraccountpref { get; set; }
    }
}
