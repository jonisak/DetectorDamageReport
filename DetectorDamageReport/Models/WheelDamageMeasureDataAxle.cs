using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class WheelDamageMeasureDataAxle
    {
        public long WheelDamageMeasureDataAxleId { get; set; }
        public float? AxleLoad { get; set; }
        public float? LeftRightLoadRatio { get; set; }
        public long MeasurementValueId { get; set; }

        public virtual MeasurementValue MeasurementValue { get; set; }
    }
}
