using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class AlarmReportImage
    {
        public int AlarmReportImageId { get; set; }
        public string Description { get; set; }
        public int AlarmReportId { get; set; }

        public virtual AlarmReport AlarmReport { get; set; }
        public virtual AlarmReportImageBin AlarmReportImageBin { get; set; }
        public virtual AlarmReportImageThumbnailBin AlarmReportImageThumbnailBin { get; set; }
    }
}
