using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class WheelDamageMeasureDataVehicle
    {
        public long WheelDamageMeasureDataVehicleId { get; set; }
        public int? FrontRearLoadRatio { get; set; }
        public int? LeftRightLoadRatio { get; set; }
        public int? WeightInTons { get; set; }
        public long VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
