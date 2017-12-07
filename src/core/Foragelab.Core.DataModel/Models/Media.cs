using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Media
    {
        public int MediaId { get; set; }
        public string MediaName { get; set; }
        public string MediaDescription { get; set; }
        public string FileName { get; set; }
        public string MediaPath { get; set; }
        public string MediaType { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedDt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedDt { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
