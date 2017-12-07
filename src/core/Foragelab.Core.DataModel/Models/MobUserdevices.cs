using System;
using System.Collections.Generic;

namespace Foragelab.Core.DataModel
{
    public partial class MobUserdevices
    {
        public int UserDeviceId { get; set; }
        public Guid? UserId { get; set; }
        public string DeviceId { get; set; }
        public string DeviceType { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDt { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdatedDt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public string UniqueDeviceId { get; set; }
        public string Osversion { get; set; }
        public string DeviceName { get; set; }
    }
}
