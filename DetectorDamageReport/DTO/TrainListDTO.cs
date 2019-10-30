using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class TrainListDTO
    {
        public int? TotalCount { get; set; }

        public double TrainId { get; set; }
        public string TrainOperator { get; set; }
        public string TrainNumber { get; set; }
        public string TrainDirection { get; set; }
        public int VehicleCount { get; set; }

        public string MessageSent { get; set; }
        public string SGLN { get; set; }
        public bool isWheelDamage { get; set; }
        public bool isHotBoxHotWheel { get; set; }
        public bool TrainHasAlarmItem { get; set; }

        public DetectorDTO Detector { get; set; }
        public AlarmReportDTO AlarmReport { get; set; }

        

    }
}
