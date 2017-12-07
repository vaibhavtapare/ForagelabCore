using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Cmsmedia
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        public long? CmspageMlid { get; set; }
        public int? BlurbId { get; set; }

        public Cmspageml CmspageMl { get; set; }
    }
}
