using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class TagLabels
    {
        public long TagLabelId { get; set; }
        public int TagProductId { get; set; }
        public string TagLabel { get; set; }
        public decimal? TagValueMin { get; set; }
        public decimal? TagValueMax { get; set; }
        public string TagUnit { get; set; }
        public string TagMap { get; set; }
    }
}
