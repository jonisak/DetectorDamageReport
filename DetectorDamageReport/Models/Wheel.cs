using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Wheel
    {
        public Wheel()
        {
            Alert = new HashSet<Alert>();
            MeasurementValue = new HashSet<MeasurementValue>();
        }

        public long WheelId { get; set; }
        public long AxleId { get; set; }

        public virtual Axle Axle { get; set; }
        public virtual ICollection<Alert> Alert { get; set; }
        public virtual ICollection<MeasurementValue> MeasurementValue { get; set; }
    }
}
