using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class WheelDamageMeasureDataVehicleDTO
    {
        public double WheelDamageMeasureDataVehicleId { get; set; }

        public float FrontRearLoadRatio { get; set; }
        public float LeftRightLoadRatio { get; set; }

        public float WeightInTons { get; set; }
    }
}
