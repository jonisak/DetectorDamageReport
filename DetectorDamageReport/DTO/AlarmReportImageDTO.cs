using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.DTO
{
    public class AlarmReportImageDTO
    {
        public int AlarmReportImageId { get; set; }
        public string Name { get; set; }
        public string Header { get; set; }
        public string Description { get; set; }
        public AlarmReportImageBinDTO alarmReportImageBinDTO { get; set; }
        public AlarmReportImageThumbnailBinDTO alarmReportImageThumbnailBinDTO { get; set; }

        public int AlarmReportId { get; set; }



    }
}
