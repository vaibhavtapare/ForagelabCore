using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ValDmValidData
    {
        public long DmValidId { get; set; }
        public long? DmRawid { get; set; }
        public bool? IsDuplicated { get; set; }
        public bool? IsDmvalid { get; set; }
        public bool? IsDmrecheck { get; set; }
        public string DmOutput { get; set; }
        public string ReviewerNotes { get; set; }
        public DateTime? CreatedDt { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public bool? IsActive { get; set; }
    }
}
