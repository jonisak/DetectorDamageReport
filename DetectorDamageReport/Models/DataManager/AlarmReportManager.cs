using DetectorDamageReport.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.PixelFormats;

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
            if (alarmReportDTO.AlarmReportId != null)
            {
                return UpdateAlarmReport(alarmReportDTO);
            }
            else
            {
                var alarmReport = new AlarmReport();
                alarmReport.AlarmReportReason = _detectorDamageReportContext.AlarmReportReason.Where(o => o.AlarmReportReasonId == alarmReportDTO.alarmReportReasonDTO.AlarmReportReasonId).FirstOrDefault();

                alarmReport.Comment = alarmReportDTO.Comment;
                alarmReport.ReportedDateTime = Convert.ToDateTime(alarmReportDTO.ReportedDateTime);
                alarmReport.TrainId = (long)alarmReportDTO.TrainId;
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

            var alarmReportReason = _detectorDamageReportContext.AlarmReportReason.Where(o => o.AlarmReportReasonId == alarmReport.AlarmReportReasonId).FirstOrDefault();
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
                TrainId = alarmReport.TrainId
                //trainDTO = new TrainManager().GetTrain(alarmReport.TrainId)
            };
        }

        public AlarmReportDTO GetAlarmReportById(int id)
        {

            var alarmReport = _detectorDamageReportContext.AlarmReport.Where(o => o.AlarmReportId == id).FirstOrDefault();

            if (alarmReport == null)
            {
                return null;
            }

            var alarmReportReason = _detectorDamageReportContext.AlarmReportReason.Where(o => o.AlarmReportReasonId == alarmReport.AlarmReportReasonId).FirstOrDefault();
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
                TrainId = alarmReport.TrainId
                //trainDTO = new TrainManager().GetTrain(alarmReport.TrainId)
            };
        }


        public AlarmReportDTO UpdateAlarmReport(AlarmReportDTO alarmReportDTO)
        {

            var alarmReport = _detectorDamageReportContext.AlarmReport.Where(o => o.AlarmReportId == alarmReportDTO.AlarmReportId).FirstOrDefault();

            if (alarmReport == null)
            {
                return null;
            }

            var alarmReportReason = _detectorDamageReportContext.AlarmReportReason.Where(o => o.AlarmReportReasonId == alarmReportDTO.alarmReportReasonDTO.AlarmReportReasonId).FirstOrDefault();
            if (alarmReportReason == null)
            {
                return null;
            }



            alarmReport.AlarmReportReason = alarmReportReason;
            alarmReport.Comment = alarmReportDTO.Comment;

            _detectorDamageReportContext.SaveChanges();

            return GetAlarmReportById(alarmReport.AlarmReportId);
        }


        public void UploadImage(AlarmReportImageDTO alarmReportImageDTO)
        {
            byte[] decodedStringInBytes = Convert.FromBase64String(alarmReportImageDTO.alarmReportImageBinDTO.Image);
            MemoryStream imgStream = new MemoryStream();
            using (Image<Rgba32> image = Image.Load(decodedStringInBytes))
            {
                image.Mutate(x => x
                     .Resize(100, 100)
                     .Grayscale());
                image.Save(imgStream, new SixLabors.ImageSharp.Formats.Jpeg.JpegEncoder());

            }

            byte[] imageContent = imgStream.GetBuffer();
            var alarmReportImage = new AlarmReportImage();
            alarmReportImage.AlarmReportId = alarmReportImageDTO.AlarmReportId;
            var alarmReportImageBin = new AlarmReportImageBin();
            alarmReportImageBin.AlarmReportImage = alarmReportImage;
            alarmReportImageBin.Image = decodedStringInBytes;
            var alarmReportImageThumbnailBin = new AlarmReportImageThumbnailBin();
            alarmReportImageThumbnailBin.AlarmReportImage = alarmReportImage;
            alarmReportImageThumbnailBin.Image = imageContent;
            alarmReportImage.Header = alarmReportImageDTO.Header;
            alarmReportImage.Description = alarmReportImageDTO.Description;

            _detectorDamageReportContext.AlarmReportImage.Add(alarmReportImage);
            _detectorDamageReportContext.AlarmReportImageBin.Add(alarmReportImageBin);
            _detectorDamageReportContext.AlarmReportImageThumbnailBin.Add(alarmReportImageThumbnailBin);
            _detectorDamageReportContext.SaveChanges();
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
