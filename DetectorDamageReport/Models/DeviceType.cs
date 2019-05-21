using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class DeviceType
    {
        public DeviceType()
        {
            Wheel = new HashSet<Wheel>();
        }

        public int DeviceTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Wheel> Wheel { get; set; }
    }
}
