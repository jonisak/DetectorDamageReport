using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class AlertDTO
    {
        public double AlertId { get; set; }
        public string MeasurementType { get; set; }
        public string DecriptionText { get; set; }
        public string AlarmCode { get; set; }
        public string AlarmLevel { get; set; }
    }
}
