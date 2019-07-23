using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class WheelDamageMeasureDataVehicle
    {
        public long WheelDamageMeasureDataVehicleId { get; set; }
        public long MeasurementValueId { get; set; }
        public float FrontRearLoadRatio { get; set; }
        public float LeftRightLoadRatio { get; set; }
        public float WeightInTons { get; set; }

        public virtual MeasurementValue MeasurementValue { get; set; }
    }
}
