using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class IStEqLookup
    {
        public int Id { get; set; }
        public int FeedCode { get; set; }
        public string FeedType { get; set; }
        public string St { get; set; }
        public string Eq { get; set; }
    }
}
