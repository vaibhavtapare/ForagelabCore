using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class FarmFeedCodes
    {
        public int FarmFeedId { get; set; }
        public int? FarmFeedCode { get; set; }
        public string FarmFeedType { get; set; }
        public bool? IsHay { get; set; }
        public bool? IsFarm { get; set; }
    }
}
