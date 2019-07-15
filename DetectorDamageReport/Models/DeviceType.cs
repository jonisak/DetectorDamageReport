using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class DeviceType
    {
        public DeviceType()
        {
            MeasurementValue = new HashSet<MeasurementValue>();
        }

        public int DeviceTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MeasurementValue> MeasurementValue { get; set; }
    }
}
