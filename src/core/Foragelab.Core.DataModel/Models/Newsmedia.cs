using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class Newsmedia
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        public int? NewsId { get; set; }

        public News News { get; set; }
    }
}
