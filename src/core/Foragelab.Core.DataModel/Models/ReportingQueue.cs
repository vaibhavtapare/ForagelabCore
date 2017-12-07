using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ReportingQueue
    {
        public Guid Id { get; set; }
        public string AccountCode { get; set; }
        public string FarmName { get; set; }
        public string UserName { get; set; }
        public string TransmissionMethod { get; set; }
        public string Fax { get; set; }
        public bool? IsFaxAnyTime { get; set; }
        public string Email { get; set; }
        public string BatchCodes { get; set; }
        public string ReportPreference { get; set; }
        public bool? IsCopyTo { get; set; }
        public string CopyToName { get; set; }
        public Guid? UserId { get; set; }
        public string ReportName { get; set; }
    }
}
