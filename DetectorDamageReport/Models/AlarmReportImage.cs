using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class AlarmReportImage
    {
        public AlarmReportImage()
        {
            AlarmReportImageBin = new HashSet<AlarmReportImageBin>();
            AlarmReportImageThumbnailBin = new HashSet<AlarmReportImageThumbnailBin>();
        }

        public int AlarmReportImageId { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public int AlarmReportId { get; set; }

        public virtual AlarmReport AlarmReport { get; set; }
        public virtual ICollection<AlarmReportImageBin> AlarmReportImageBin { get; set; }
        public virtual ICollection<AlarmReportImageThumbnailBin> AlarmReportImageThumbnailBin { get; set; }
    }
}
