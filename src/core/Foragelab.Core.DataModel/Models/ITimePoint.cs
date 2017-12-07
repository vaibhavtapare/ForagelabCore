using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ITimePoint
    {
        public ITimePoint()
        {
            INdfdinvitro = new HashSet<INdfdinvitro>();
        }

        public int TimePointId { get; set; }
        public int TimePoint { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<INdfdinvitro> INdfdinvitro { get; set; }
    }
}
