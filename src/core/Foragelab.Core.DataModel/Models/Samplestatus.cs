using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Samplestatus
    {
        public int SamplesStatusId { get; set; }
        public int? StatusId { get; set; }
        public long? SamplesId { get; set; }
        public DateTime? StatusDate { get; set; }
        public string UserId { get; set; }
    }
}
