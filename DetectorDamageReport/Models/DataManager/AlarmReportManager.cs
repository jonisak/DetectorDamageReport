using DetectorDamageReport.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.Models.DataManager
{
    public class AlarmReportManager
    {

        readonly DetectorDamageReportContext _detectorDamageReportContext;

        public AlarmReportManager(DetectorDamageReportContext context)
        {
            _detectorDamageReportContext = context;
        }

        public AlarmReportManager()
        {
            _detectorDamageReportContext = new DetectorDamageReportContext();
        }


        public void Add(AlarmReportDTO alarmReportDTO)
        {
            var alarmReport = new AlarmReport();
            alarmReport.AlarmReportReason = _detectorDamageReportContext.AlarmReportReason.Where(o => o.AlarmReportReasonId == alarmReportDTO.alarmReportReasonDTO.AlarmReportReasonId).FirstOrDefault();

            alarmReport.Comment = alarmReportDTO.Comment;
            alarmReport.ReportedDateTime = Convert.ToDateTime(alarmReportDTO.ReportedDateTime);
            alarmReport.TrainId = (long) alarmReportDTO.trainDTO.TrainId;
            _detectorDamageReportContext.AlarmReport.Add(alarmReport);
            _detectorDamageReportContext.SaveChanges();
        }

    }
}
