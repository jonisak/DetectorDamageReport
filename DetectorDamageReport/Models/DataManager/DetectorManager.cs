using DetectorDamageReport.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.Models.DataManager
{
    public class DetectorManager
    {
        readonly DetectorDamageReportContext _detectorDamageReportContext;
        public DetectorManager(DetectorDamageReportContext context)
        {
            _detectorDamageReportContext = context;
        }
        public DetectorManager()
        {
            _detectorDamageReportContext = new DetectorDamageReportContext();
        }



        public List<DetectorDTO> GetDetectorList()
        {
            var query = _detectorDamageReportContext.Detector.Where(o=>o.DetectorType != "RFID Reader")
                .AsQueryable().ToList();

            var detectorList = new List<DetectorDTO>();

            foreach (var detector in query)
            {
                detectorList.Add(new DetectorDTO()
                {
                    DetectorId = detector.DetectorId,
                    DetectorType = detector.DetectorType,
                    Name = detector.Name,
                    SGLN = detector.Sgln,
                    Latitude = detector.Latitude,
                    Longitude = detector.Longitude
                });
            }
            return detectorList;
        }
    }
}
