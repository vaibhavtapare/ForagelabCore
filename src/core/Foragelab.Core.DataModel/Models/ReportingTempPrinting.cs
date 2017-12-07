using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportingTempPrinting
    {
        public int Id { get; set; }
        public long? SamplesId { get; set; }
        public string LabId { get; set; }
        public string MailFor { get; set; }
        public bool? IsCopyTo { get; set; }
        public string ReportName { get; set; }
        public bool? IsReadyToPrint { get; set; }
        public bool? IsEnvelope { get; set; }
    }
}
