using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class AlarmReportDTO
    {
        public int? AlarmReportId { get; set; }
        public AlarmReportReasonDTO alarmReportReasonDTO { get; set; }
        public long TrainId { get; set; }
        public string ReportedDateTime { get; set; }
        public string Comment { get; set; }

    }
}
