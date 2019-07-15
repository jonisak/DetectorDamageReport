using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class WheelDamageMeasureDataWheel
    {
        public long WheelDamageMeasureDataWheelId { get; set; }
        public double? LeftWheelDamageDistributedLoadValue { get; set; }
        public double? LeftWheelDamageMeanValue { get; set; }
        public double? LeftWheelDamagePeakValue { get; set; }
        public double? LeftWheelDamageQualityFactor { get; set; }
        public double? RightWheelDamageDistributedLoadValue { get; set; }
        public double? RightWheelDamageMeanValue { get; set; }
        public double? RightWheelDamagePeakValue { get; set; }
        public double? RightWheelDamageQualityFactor { get; set; }
        public long MeasurementValueId { get; set; }

        public virtual MeasurementValue MeasurementValue { get; set; }
    }
}
