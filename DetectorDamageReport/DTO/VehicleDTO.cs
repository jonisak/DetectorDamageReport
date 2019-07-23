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

        public int Speed { get; set; }

        public int AxleCount { get; set; }

        public List<AxleDTO> AxleList { get; set; }

        public List<WheelDamageMeasureDataVehicleDTO> WheelDamageMeasureDataVehicleList { get; set; }



        public List<AlertDTO> AlertList { get; set; }



    }
}
