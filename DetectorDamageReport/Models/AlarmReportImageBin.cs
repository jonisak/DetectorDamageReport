using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class AlarmReportImageBin
    {
        public int AlarmReportImageBinId { get; set; }
        public byte[] Image { get; set; }
        public int AlarmReportImageId { get; set; }

        public virtual AlarmReportImage AlarmReportImage { get; set; }
    }
}
