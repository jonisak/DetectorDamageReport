using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class TrainDTO
    {
        public int? TotalCount { get; set; }

        public double TrainId { get; set; }
        public string TrainOperator { get; set; }
        public string TrainNumber { get; set; }
        public string TrainDirection { get; set; }
        public int VehicleCount { get; set; }

        public string MessageSent { get; set; }
        public string Detector { get; set; }

         public List<VehicleDTO> Vehicles { get; set; }

        public List<AlertDTO> AlertList { get; set; }


    }
}
