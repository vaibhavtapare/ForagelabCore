using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class TblLinkNetUserToSamplesResultsSep02
    {
        public int NetUserResultsLinkId { get; set; }
        public string NetUserAccountLink { get; set; }
        public string SamplesResultsAccountLink { get; set; }
        public decimal UserDaysToView { get; set; }
    }
}
