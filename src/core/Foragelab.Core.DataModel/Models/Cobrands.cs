using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Cobrands
    {
        public int CoBrandId { get; set; }
        public string AccountCode { get; set; }
        public string BusinessName { get; set; }
        public string HeaderImageName { get; set; }
        public string FooterImageName { get; set; }
        public bool? IsAffiliate { get; set; }
        public bool? IsClient { get; set; }
        public bool? IsActive { get; set; }
    }
}
