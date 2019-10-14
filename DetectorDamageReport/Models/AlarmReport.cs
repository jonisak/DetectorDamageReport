using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class AlarmReport
    {
        public int AlarmReportId { get; set; }
        public int AlarmReportReasonId { get; set; }
        public long TrainId { get; set; }
        public DateTime ReportedDateTime { get; set; }
        public string Comment { get; set; }

        public virtual AlarmReportReason AlarmReportReason { get; set; }
        public virtual Train Train { get; set; }
    }
}
