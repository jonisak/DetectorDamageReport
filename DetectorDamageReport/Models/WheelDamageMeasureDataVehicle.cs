using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class WheelDamageMeasureDataVehicle
    {
        public long WheelDamageMeasureDataVehicleId { get; set; }
        public long MeasurementValueId { get; set; }
        public double FrontRearLoadRatio { get; set; }
        public double LeftRightLoadRatio { get; set; }
        public double WeightInTons { get; set; }

        public virtual MeasurementValue MeasurementValue { get; set; }
    }
}
