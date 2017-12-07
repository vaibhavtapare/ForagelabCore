using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class ValMethodTypes
    {
        public ValMethodTypes()
        {
            ValMethodExceptions = new HashSet<ValMethodExceptions>();
        }

        public long MethodTypeId { get; set; }
        public long? MethodId { get; set; }
        public string MethodType { get; set; }
        public string MethodJoin { get; set; }
        public int? OrderBy { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<ValMethodExceptions> ValMethodExceptions { get; set; }
    }
}
