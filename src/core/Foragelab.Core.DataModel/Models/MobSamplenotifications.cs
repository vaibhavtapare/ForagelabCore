using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobSamplenotifications
    {
        public int NotificationId { get; set; }
        public Guid UserId { get; set; }
        public string SampleId { get; set; }
        public string SampleMessage { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        public AspnetUsers User { get; set; }
    }
}
