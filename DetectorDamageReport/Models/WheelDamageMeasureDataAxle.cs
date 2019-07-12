using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class WheelDamageMeasureDataAxle
    {
        public long WheelDamageMeasureDataAxleId { get; set; }
        public int? AxleLoad { get; set; }
        public int? LeftRightLoadRatio { get; set; }
        public long MeasurementValueId { get; set; }

        public virtual MeasurementValue MeasurementValue { get; set; }
    }
}
