using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class SampleUserNotes
    {
        public long SampleUserNotesId { get; set; }
        public long? SampleId { get; set; }
        public Guid? UserId { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Reviewed { get; set; }
        public bool? Executed { get; set; }

        public Samples Sample { get; set; }
    }
}
