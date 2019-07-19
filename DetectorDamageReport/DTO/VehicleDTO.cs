using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class VehicleDTO
    {

        public long VehicleId { get; set; }
        public string VehicleNumber { get; set; }

        public long Speed { get; set; }

        public int AxleCount { get; set; }


    }
}
