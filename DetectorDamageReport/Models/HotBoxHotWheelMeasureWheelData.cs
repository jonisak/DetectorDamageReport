﻿using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class HotBoxHotWheelMeasureWheelData
    {
        public long HotBoxHotWheelMeasureWheelDataId { get; set; }
        public int? HotBoxLeftValue { get; set; }
        public int? HotBoxRightValue { get; set; }
        public int? HotWheelLeftValue { get; set; }
        public int? HotWheelRightValue { get; set; }
        public long MeasurementValueId { get; set; }

        public virtual MeasurementValue MeasurementValue { get; set; }
    }
}
