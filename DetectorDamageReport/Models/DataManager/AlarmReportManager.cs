using DetectorDamageReport.DTO;
using Microsoft.EntityFrameworkCore;
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


        public AlarmReportDTO Add(AlarmReportDTO alarmReportDTO)
        {
            if (_detectorDamageReportContext.AlarmReport.Where(o => o.TrainId == alarmReportDTO.trainDTO.TrainId).Count() > 0)
            {
                return UpdateAlarmReport(alarmReportDTO);
            }
            else
            {
                var alarmReport = new AlarmReport();
                alarmReport.AlarmReportReason = _detectorDamageReportContext.AlarmReportReason.Where(o => o.AlarmReportReasonId == alarmReportDTO.alarmReportReasonDTO.AlarmReportReasonId).FirstOrDefault();

                alarmReport.Comment = alarmReportDTO.Comment;
                alarmReport.ReportedDateTime = Convert.ToDateTime(alarmReportDTO.ReportedDateTime);
                alarmReport.TrainId = (long)alarmReportDTO.trainDTO.TrainId;
                _detectorDamageReportContext.AlarmReport.Add(alarmReport);
                _detectorDamageReportContext.SaveChanges();
                return GetAlarmReportById(alarmReport.AlarmReportId);
            }
        }


        public AlarmReportDTO GetAlarmReportByTrainId(int id)
        {

            var alarmReport = _detectorDamageReportContext.AlarmReport.Where(o => o.TrainId == id).FirstOrDefault();

            if (alarmReport == null)
            {
                return null;
            }

            var alarmReportReason = _detectorDamageReportContext.AlarmReportReason.Where(o => o.AlarmReportReasonId == alarmReport.AlarmReportId).FirstOrDefault();
            if (alarmReportReason == null)
            {
                return null;
            }


            var alarmReportReasonDTO = new AlarmReportReasonDTO()
            {
                AlarmReportReasonId = alarmReportReason.AlarmReportReasonId
                ,
                Name = alarmReportReason.Name
            };




            return new AlarmReportDTO()
            {
                AlarmReportId = alarmReport.AlarmReportId
                ,
                alarmReportReasonDTO = alarmReportReasonDTO,
                Comment = alarmReport.Comment,
                ReportedDateTime = alarmReport.ReportedDateTime.ToString("yyyy-MM-ddTHH:mm:ss.sssZ"),
                trainDTO = new TrainManager().GetTrain(alarmReport.TrainId)
            };
        }

        public AlarmReportDTO GetAlarmReportById(int id)
        {

            var alarmReport = _detectorDamageReportContext.AlarmReport.Where(o => o.AlarmReportId == id).FirstOrDefault();

            if (alarmReport == null)
            {
                return null;
            }

            var alarmReportReason = _detectorDamageReportContext.AlarmReportReason.Where(o => o.AlarmReportReasonId == alarmReport.AlarmReportId).FirstOrDefault();
            if (alarmReportReason == null)
            {
                return null;
            }


            var alarmReportReasonDTO = new AlarmReportReasonDTO()
            {
                AlarmReportReasonId = alarmReportReason.AlarmReportReasonId
                ,
                Name = alarmReportReason.Name
            };




            return new AlarmReportDTO()
            {
                AlarmReportId = alarmReport.AlarmReportId
                ,
                alarmReportReasonDTO = alarmReportReasonDTO,
                Comment = alarmReport.Comment,
                ReportedDateTime = alarmReport.ReportedDateTime.ToString("yyyy-MM-ddTHH:mm:ss.sssZ"),
                trainDTO = new TrainManager().GetTrain(alarmReport.TrainId)
            };
        }


        public AlarmReportDTO UpdateAlarmReport(AlarmReportDTO alarmReportDTO)
        {

            var alarmReport = _detectorDamageReportContext.AlarmReport.Where(o => o.AlarmReportId == alarmReportDTO.AlarmReportId).FirstOrDefault();

            if (alarmReport == null)
            {
                return null;
            }

            var alarmReportReason = _detectorDamageReportContext.AlarmReportReason.Where(o => o.AlarmReportReasonId == alarmReport.AlarmReportId).FirstOrDefault();
            if (alarmReportReason == null)
            {
                return null;
            }



            alarmReport.AlarmReportReasonId = alarmReportReason.AlarmReportReasonId;
            alarmReport.Comment = alarmReportDTO.Comment;

            _detectorDamageReportContext.SaveChanges();

            return GetAlarmReportById(alarmReport.AlarmReportId);
        }



        //public List<TrainListDTO> GetUserAlarmReports(String userId, TrainFilterDTO trainFilterDTO)
        //{
        //    int? totalCount = null;
        //    int skipRows = 0;
        //    int take = 10;

        //    var query = _detectorDamageReportContext.Train
        //        .Include(x => x.Message)
        //        .Include(x => x.Message).ThenInclude(x => x.Train)
        //        .Include(x => x.Message).ThenInclude(x => x.Train).ThenInclude(x => x.TrainDirection)
        //        .Include(x => x.Message).ThenInclude(x => x.Train).ThenInclude(x => x.TrainOperator)
        //        .Include(x => x.Message).ThenInclude(x => x.Detector)
        //        .Include(x => x.AlarmReport)
        //        .Include(x => x.Vehicle)
        //        .Include(x => x.TrainDirection)
        //        .Include(x => x.TrainOperator)

        //        .AsQueryable();

        //    if (trainFilterDTO.ShowTrainWithAlarmOnly)
        //    {
        //        query = query.Where(o => o.TrainHasAlarms == true);
        //    }


        //    if (trainFilterDTO.TrainNumber.Length > 0)
        //    {
        //        query = query.Where(o => o.TrainNumber == trainFilterDTO.TrainNumber);

        //    }


        //    if (trainFilterDTO.FromDate.Length > 0)
        //    {
        //        DateTime fromDateValue;

        //        if (DateTime.TryParse(trainFilterDTO.FromDate, out fromDateValue))
        //        {
        //            query = query.Where(o => o.Message.SendTimeStamp >= fromDateValue.Date);
        //        }
        //    }
        //    if (trainFilterDTO.ToDate.Length > 0)
        //    {
        //        DateTime toDateValue;
        //        if (DateTime.TryParse(trainFilterDTO.ToDate, out toDateValue))
        //        {

        //            query = query.Where(o => o.Message.SendTimeStamp < toDateValue.Date.AddDays(1));
        //        }
        //    }


        //    if (trainFilterDTO.SelectedDetectorsDTOList.Count > 0)
        //    {
        //        List<int> values = trainFilterDTO.SelectedDetectorsDTOList.Select(o => o.DetectorId).ToList();
        //        List<int?> valuesCast = values.Cast<int?>().ToList();
        //        query = query.Where(x => valuesCast.Contains(x.Message.DetectorId));
        //    }


        //    if (trainFilterDTO.Sort == "LATEST")
        //    {
        //        query = query.OrderByDescending(o => o.Message.SendTimeStamp);
        //    }
        //    else
        //    {
        //        query = query.OrderBy(o => o.Message.SendTimeStamp);
        //    }

        //    var IsHotBoxHotWheel = false;
        //    var IsWheelDamage = false;
        //    foreach (var deviceType in trainFilterDTO.DeviceTypeDTOList)
        //    {
        //        if (deviceType.DeviceType == "HOTBOXHOTWHEEL")
        //        {
        //            if (deviceType.Selected)
        //            {
        //                IsHotBoxHotWheel = true;
        //            }
        //            else
        //            {
        //                IsHotBoxHotWheel = false;
        //            }
        //        }

        //        if (deviceType.DeviceType == "WHEELDAMAGE")
        //        {
        //            if (deviceType.Selected)
        //            {
        //                IsWheelDamage = true;
        //            }
        //            else
        //            {
        //                IsWheelDamage = false;

        //            }
        //        }
        //    }

        //    query = query.Where(entity => entity.IsHotBoxHotWheel == IsHotBoxHotWheel || entity.IsWheelDamage == IsWheelDamage);



        //    if (trainFilterDTO.Page.HasValue && trainFilterDTO.PageSize.HasValue)
        //    {
        //        skipRows = (trainFilterDTO.Page.Value - 1) * trainFilterDTO.PageSize.Value;
        //        take = trainFilterDTO.PageSize.Value;
        //        if (trainFilterDTO.Page == 1)
        //        {
        //            int count = query.Count();
        //            if (count > 10000)
        //            {
        //                totalCount = 10000;
        //            }
        //            else
        //            {
        //                totalCount = query.Count();
        //            }
        //        }
        //    }


        //    var trains = query.Skip(skipRows).Take(take).ToList();

        //    //Lista med tågset
        //    List<TrainListDTO> trainListDTOs = new List<TrainListDTO>();
        //    //För varje tåg i tågsettet
        //    foreach (var train in trains)
        //    {
        //        trainListDTOs.Add(new TrainListDTO()
        //        {
        //            TrainId = train.TrainId,
        //            TrainDirection = train.TrainDirection.Name,
        //            TrainNumber = train.TrainNumber,
        //            TrainOperator = train.TrainOperator.Name,
        //            MessageSent = train.Message.SendTimeStamp.ToString("yyyy-MM-ddTHH:mm:ss.sssZ"),


        //            SGLN = train.Message.LocationId,
        //            isWheelDamage = train.IsWheelDamage,
        //            isHotBoxHotWheel = train.IsHotBoxHotWheel,
        //            TrainHasAlarmItem = train.TrainHasAlarms,
        //            Detector = train.Message.DetectorId.HasValue ? new DetectorDTO()
        //            {
        //                DetectorId = train.Message.Detector.DetectorId,
        //                DetectorType = train.Message.Detector.DetectorType,
        //                Latitude = train.Message.Detector.Latitude,
        //                Longitude = train.Message.Detector.Longitude,
        //                Name = train.Message.Detector.Name,
        //                SGLN = train.Message.Detector.Sgln
        //            } : null,
        //            VehicleCount = train.VehicleCount.HasValue ? train.VehicleCount.Value : 0,
        //            TotalCount = totalCount ?? null
        //        });

        //    }
        //    return trainListDTOs;
        //}

    }
}
