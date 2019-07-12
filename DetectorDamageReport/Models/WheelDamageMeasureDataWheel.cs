using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class WheelDamageMeasureDataWheel
    {
        public long WheelDamageMeasureDataWheelId { get; set; }
        public int? LeftWheelDamageDistributedLoadValue { get; set; }
        public int? LeftWheelDamageMeanValue { get; set; }
        public int? LeftWheelDamagePeakValue { get; set; }
        public int? LeftWheelDamageQualityFactor { get; set; }
        public int? RightWheelDamageDistributedLoadValue { get; set; }
        public int? RightWheelDamageMeanValue { get; set; }
        public int? RightWheelDamagePeakValue { get; set; }
        public int? RightWheelDamageQualityFactor { get; set; }
        public long MeasurementValueId { get; set; }

        public virtual MeasurementValue MeasurementValue { get; set; }
    }
}
