using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Clientphotos
    {
        public int ClientPhotoId { get; set; }
        public long SampleEntryId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoDesc { get; set; }
        public string PhotoPath { get; set; }
        public DateTime? CreatedDt { get; set; }
        public Guid? CreatedBy { get; set; }
    }
}
