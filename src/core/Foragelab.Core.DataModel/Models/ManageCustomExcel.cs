using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ManageCustomExcel
    {
        public long ManageCustomExcelId { get; set; }
        public Guid? ShareByUserId { get; set; }
        public Guid? SharedWithUserId { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int? ReportPrefId { get; set; }
        public Guid? CreatedBy { get; set; }
        public int? SharedReportPrefId { get; set; }
    }
}
