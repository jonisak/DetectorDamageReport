﻿using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class WheelDamageMeasureDataWheel
    {
        public long WheelDamageMeasureDataWheelId { get; set; }
        public float? LeftWheelDamageDistributedLoadValue { get; set; }
        public float? LeftWheelDamageMeanValue { get; set; }
        public float? LeftWheelDamagePeakValue { get; set; }
        public float? LeftWheelDamageQualityFactor { get; set; }
        public float? RightWheelDamageDistributedLoadValue { get; set; }
        public float? RightWheelDamageMeanValue { get; set; }
        public float? RightWheelDamagePeakValue { get; set; }
        public float? RightWheelDamageQualityFactor { get; set; }
        public long MeasurementValueId { get; set; }

        public virtual MeasurementValue MeasurementValue { get; set; }
    }
}
