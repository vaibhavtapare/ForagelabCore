using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Billtoaccounts
    {
        public int BillToAccountId { get; set; }
        public Guid? UserId { get; set; }
        public string BillToAccountAddress { get; set; }
        public DateTime? CreatedDt { get; set; }
    }
}
