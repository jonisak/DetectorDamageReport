using System.Collections.Generic;

namespace DetectorDamageReport.DTO
{
    public class WheelDTO
    {
        public double WheelId { get; set; }

        public List<WheelDamageMeasureDataWheelDTO> WheelDamageMeasureDataWheelList { get; set; }
        public List<HotBoxHotWheelMeasureWheelDataDTO> HotBoxHotWheelMeasureWheelDataList { get; set; }

        public List<AlertDTO> AlertList { get; set; }



    }
}


