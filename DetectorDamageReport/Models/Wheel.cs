using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Wheel
    {
        public Wheel()
        {
            MeasurementValue = new HashSet<MeasurementValue>();
        }

        public long WheelId { get; set; }
        public int DeviceTypeId { get; set; }
        public long AxleId { get; set; }

        public virtual Axle Axle { get; set; }
        public virtual DeviceType DeviceType { get; set; }
        public virtual ICollection<MeasurementValue> MeasurementValue { get; set; }
    }
}
