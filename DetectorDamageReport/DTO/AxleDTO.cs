using System.Collections.Generic;

namespace DetectorDamageReport.DTO
{
    public class AxleDTO
    {

        public double AxleId { get; set; }
        public int? AxleNumber { get; set; }

        public List<WheelDamageMeasureDataAxleDTO> WheelDamageMeasureDataAxleList { get; set; }
        public List<WheelDTO> WheelList { get; set; }

        public List<AlertDTO> AlertList { get; set; }

    }
}