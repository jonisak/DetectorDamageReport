using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class WheelDamageMeasureDataVehicleDTO
    {
        public double WheelDamageMeasureDataVehicleId { get; set; }

        public double FrontRearLoadRatio { get; set; }
        public double LeftRightLoadRatio { get; set; }

        public double WeightInTons { get; set; }
    }
}
