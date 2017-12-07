using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SmImportPreference
    {
        public long ImportPreferenceId { get; set; }
        public long UserDetailsId { get; set; }
        public int? ImportTypeId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
