using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class AlarmReportReason
    {
        public AlarmReportReason()
        {
            AlarmReport = new HashSet<AlarmReport>();
        }

        public int AlarmReportReasonId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AlarmReport> AlarmReport { get; set; }
    }
}
