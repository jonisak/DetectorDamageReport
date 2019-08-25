using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DetectorDamageReport.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace DetectorDamageReport.Models.DataManager
{
    public class TrainManager
    {
        readonly DetectorDamageReportContext _detectorDamageReportContext;
        public TrainManager(DetectorDamageReportContext context)
        {
            _detectorDamageReportContext = context;
        }
        public TrainManager()
        {
            _detectorDamageReportContext = new DetectorDamageReportContext();
        }

        public List<TrainListDTO> GetUserTrainList(String userId, TrainFilterDTO trainFilterDTO)
        {

            int? totalCount = null;
            int skipRows = 0;
            int take = 10;

            //Ta fram en lista med användarens alla tågoperatörer
            // var trainoperators = _detectorDamageReportContext.TrainOperatorUser.Where(o => o.User.UserName == userId).Select(o => o.TrainOperatorId).Distinct().ToList();
            var query = _detectorDamageReportContext.Train
                .Include(x => x.Message)
                .Include(x => x.Message).ThenInclude(x => x.Train)
                .Include(x => x.Message).ThenInclude(x => x.Train).ThenInclude(x => x.TrainDirection)
                .Include(x => x.Message).ThenInclude(x => x.Train).ThenInclude(x => x.TrainOperator)
                .Include(x => x.Vehicle)
                .Include(x => x.TrainDirection)
                .Include(x => x.TrainOperator)
                .AsQueryable();

            if (trainFilterDTO.ShowTrainWithAlarmOnly)
            {
                query = query.Where(o => o.TrainHasAlarms == true);
            }

            if (trainFilterDTO.TrainNumber.Length > 0)
            {
                query = query.Where(o => o.TrainNumber == trainFilterDTO.TrainNumber);

            }


            if (trainFilterDTO.FromDate.Length > 0)
            {
                DateTime fromDateValue;

                if (DateTime.TryParse(trainFilterDTO.FromDate, out fromDateValue))
                {
                    query = query.Where(o => o.Message.SendTimeStamp >= fromDateValue.Date);
                }
            }
            if (trainFilterDTO.ToDate.Length > 0)
            {
                DateTime toDateValue;
                if (DateTime.TryParse(trainFilterDTO.ToDate, out toDateValue))
                {
                   
                    query = query.Where(o => o.Message.SendTimeStamp < toDateValue.Date.AddDays(1));
                }
            }

            var IsHotBoxHotWheel = false;
            var IsWheelDamage = false;
            foreach (var deviceType in trainFilterDTO.DeviceTypeDTOList)
            {
                if (deviceType.DeviceType == "HOTBOXHOTWHEEL")
                {
                    if (deviceType.Selected)
                    {
                        IsHotBoxHotWheel = true;
                    }
                    else
                    {
                        IsHotBoxHotWheel = false;
                    }
                }

                if (deviceType.DeviceType == "WHEELDAMAGE")
                {
                    if (deviceType.Selected)
                    {
                        IsWheelDamage = true;
                    }
                    else
                    {
                        IsWheelDamage = false;

                    }
                }
            }

            query = query.Where(entity => entity.IsHotBoxHotWheel == IsHotBoxHotWheel || entity.IsWheelDamage == IsWheelDamage);



            if (trainFilterDTO.Page.HasValue && trainFilterDTO.PageSize.HasValue)
            {
                skipRows = (trainFilterDTO.Page.Value - 1) * trainFilterDTO.PageSize.Value;
                take = trainFilterDTO.PageSize.Value;
                if (trainFilterDTO.Page == 1)
                {
                    int count = query.Count();
                    if (count > 10000)
                    {
                        totalCount = 10000;
                    }
                    else
                    {
                        totalCount = query.Count();
                    }
                }
            }


            var trains = query.Skip(skipRows).Take(take).ToList();

            //Lista med tågset
            List<TrainListDTO> trainListDTOs = new List<TrainListDTO>();
            //För varje tåg i tågsettet
            foreach (var train in trains)
            {
                trainListDTOs.Add(new TrainListDTO()
                {
                    TrainId = train.TrainId,
                    TrainDirection = train.TrainDirection.Name,
                    TrainNumber = train.TrainNumber,
                    TrainOperator = train.TrainOperator.Name,
                    MessageSent = train.Message.SendTimeStamp.ToShortDateString(),
                    Detector = train.Message.LocationId,
                    isWheelDamage = train.IsWheelDamage,
                    isHotBoxHotWheel = train.IsHotBoxHotWheel,
                    TrainHasAlarmItem = train.TrainHasAlarms,
                    VehicleCount = train.VehicleCount.HasValue ? train.VehicleCount.Value : 0,

                    TotalCount = totalCount ?? null
                });

            }
            return trainListDTOs;
        }



        public TrainDTO GetUserTrain(String userId, int trainId)
        {

            //Ta fram en lista med användarens alla tågoperatörer
            // var trainoperators = _detectorDamageReportContext.TrainOperatorUser.Where(o => o.User.UserName == userId).Select(o => o.TrainOperatorId).Distinct().ToList();

            var query = _detectorDamageReportContext.Train
                .Include(x => x.Message)
                .Include(x => x.Message).ThenInclude(x => x.Train)
                .Include(x => x.Message).ThenInclude(x => x.Train).ThenInclude(x => x.TrainDirection)
                .Include(x => x.Message).ThenInclude(x => x.Train).ThenInclude(x => x.TrainOperator)
                .Include(x => x.Vehicle)
                .Include(x => x.Vehicle).ThenInclude(x => x.Axle)
                .Include(x => x.Vehicle).ThenInclude(x => x.Axle).ThenInclude(x => x.Wheel)
                .Include(o => o.Vehicle).ThenInclude(o => o.MeasurementValue)
                .Include(o => o.Vehicle).ThenInclude(x => x.Axle).ThenInclude(o => o.MeasurementValue)
                .Include(o => o.Vehicle).ThenInclude(x => x.Axle).ThenInclude(x => x.Wheel).ThenInclude(o => o.MeasurementValue)
                .Include(o => o.Vehicle).ThenInclude(o => o.MeasurementValue).ThenInclude(o => o.WheelDamageMeasureDataVehicle)
                .Include(o => o.Vehicle).ThenInclude(o => o.Axle).ThenInclude(o => o.Wheel).ThenInclude(o => o.MeasurementValue).ThenInclude(o => o.WheelDamageMeasureDataWheel)
                .Include(o => o.Vehicle).ThenInclude(o => o.Axle).ThenInclude(o => o.Wheel).ThenInclude(o => o.MeasurementValue).ThenInclude(o => o.HotBoxHotWheelMeasureWheelData)
                .Include(x => x.Alert)
                .Include(x => x.Vehicle).ThenInclude(x => x.Alert)
                .Include(o => o.Vehicle).ThenInclude(o => o.MeasurementValue).ThenInclude(o => o.DeviceType)
                .Include(o => o.Vehicle).ThenInclude(o => o.Axle).ThenInclude(o => o.MeasurementValue).ThenInclude(o => o.WheelDamageMeasureDataAxle)
                .Include(o => o.Vehicle).ThenInclude(o => o.Axle).ThenInclude(o => o.Alert)
                .Include(o => o.Vehicle).ThenInclude(o => o.Axle).ThenInclude(o => o.Wheel).ThenInclude(o => o.Alert)
                .Include(x => x.TrainDirection)
                .Include(x => x.TrainOperator)
                .AsQueryable();


            var train = query.Where(o => o.TrainId == trainId).FirstOrDefault();

            var isWheelDamage = false;
            var isHotBoxHotWheel = false;
            #region Larm tågnivå
            var alertListDTOTrain = new List<AlertDTO>();
            if (train.Alert != null && train.Alert.Count > 0)
            {
                foreach (var alert in train.Alert)
                {
                    var al = new AlertDTO()
                    {
                        AlarmCode = alert.AlarmCode,
                        AlarmLevel = alert.AlarmLevel,
                        AlertId = alert.AlertId,
                        DecriptionText = alert.DecriptionText,
                        MeasurementType = alert.MeasurementType
                    };
                    alertListDTOTrain.Add(al);
                }
            }
            #endregion
            //Skapa en lista med fordon
            var vehicleDTOList = new List<VehicleDTO>();
            //Loopa igenom varje fordon i tågsettet
            foreach (var vechicle in train.Vehicle)
            {
                #region larm Fordon
                //Kontrollera om det finns något larm för fordonet. Finns larm så lägg det till fordonslarmslistan
                var alertListVehicleDTO = new List<AlertDTO>();
                if (vechicle.Alert != null && vechicle.Alert.Count() > 0)
                {
                    foreach (var alert in vechicle.Alert)
                    {
                        var al = new AlertDTO()
                        {
                            AlarmCode = alert.AlarmCode,
                            AlarmLevel = alert.AlarmLevel,
                            AlertId = alert.AlertId,
                            DecriptionText = alert.DecriptionText,
                            MeasurementType = alert.MeasurementType
                        };
                        alertListVehicleDTO.Add(al);
                    }
                }
                #endregion
                //Skapa en lista med Axlar
                var axleListDTO = new List<AxleDTO>();
                //Loopa igenom alla axlar i fordonet
                foreach (var axle in vechicle.Axle)
                {
                    #region larm Axel
                    var axleAlertList = new List<AlertDTO>();
                    if (axle.Alert != null && axle.Alert.Count > 0)
                    {

                        //Loopa igenom alla larm för en axel
                        foreach (var alertAxle in axle.Alert)
                        {
                            //Om det finns larm, lägg det till en larmlista
                            axleAlertList.Add(new AlertDTO()
                            {
                                AlarmCode = alertAxle.AlarmCode,
                                AlarmLevel = alertAxle.AlarmLevel,
                                AlertId = alertAxle.AlertId,
                                DecriptionText = alertAxle.DecriptionText,
                                MeasurementType = alertAxle.MeasurementType
                            });
                        }

                    }
                    #endregion
                    var wheelList = new List<WheelDTO>();
                    //För varje hjul på axeln
                    foreach (var wheel in axle.Wheel)
                    {
                        #region larm Hjul
                        //Skapa en larmlista för varje hjul
                        var alertListWheel = new List<AlertDTO>();
                        if (wheel.Alert != null && wheel.Alert.Count > 0)
                        {
                            foreach (var alert in wheel.Alert)
                            {
                                alertListWheel.Add(new AlertDTO()
                                {
                                    AlarmCode = alert.AlarmCode,
                                    AlarmLevel = alert.AlarmLevel,
                                    AlertId = alert.AlertId,
                                    DecriptionText = alert.DecriptionText,
                                    MeasurementType = alert.MeasurementType
                                });
                            }
                        }
                        #endregion
                        var hotBoxHotWheelMeasureWheelDataList = new List<HotBoxHotWheelMeasureWheelDataDTO>();
                        var wheelDamageMeasureDataWheelList = new List<WheelDamageMeasureDataWheelDTO>();

                        //Om hjulet har ett mätvärde 
                        if (wheel.MeasurementValue != null && wheel.MeasurementValue.Count > 0)
                        {
                            //Loopa igenom hjulets mätvärde
                            foreach (var measurementValue in wheel.MeasurementValue)
                            {
                                #region Hot Box/Hot Wheel på hjul
                                if (measurementValue.HotBoxHotWheelMeasureWheelData != null && measurementValue.HotBoxHotWheelMeasureWheelData.Count() > 0)
                                {
                                    foreach (var hotBoxHotWheelMeasureWheelData in measurementValue.HotBoxHotWheelMeasureWheelData)
                                    {
                                        hotBoxHotWheelMeasureWheelDataList.Add(new HotBoxHotWheelMeasureWheelDataDTO()
                                        {
                                            HotBoxHotWheelMeasureWheelDataId = hotBoxHotWheelMeasureWheelData.HotBoxHotWheelMeasureWheelDataId,
                                            HotBoxLeftValue = hotBoxHotWheelMeasureWheelData.HotBoxLeftValue != null ? hotBoxHotWheelMeasureWheelData.HotBoxLeftValue : null,
                                            HotBoxRightValue = hotBoxHotWheelMeasureWheelData.HotBoxRightValue != null ? hotBoxHotWheelMeasureWheelData.HotBoxRightValue : null,
                                            HotWheelLeftValue = hotBoxHotWheelMeasureWheelData.HotWheelLeftValue != null ? hotBoxHotWheelMeasureWheelData.HotWheelLeftValue : null,
                                            HotWheelRightValue = hotBoxHotWheelMeasureWheelData.HotWheelRightValue != null ? hotBoxHotWheelMeasureWheelData.HotWheelRightValue : null


                                        });
                                    }
                                    //Sätt trainDTO till ett VG/TJ meddelande (slarvigt)
                                    isHotBoxHotWheel = true;
                                }
                                #endregion
                                #region Wheel Damage mätdata på hjul
                                if (measurementValue.WheelDamageMeasureDataWheel != null && measurementValue.WheelDamageMeasureDataWheel.Count() > 0)
                                {
                                    foreach (var wheelDamageMeasureDataWheel in measurementValue.WheelDamageMeasureDataWheel)
                                    {
                                        wheelDamageMeasureDataWheelList.Add(new WheelDamageMeasureDataWheelDTO()
                                        {
                                            LeftWheelDamageDistributedLoadValue = wheelDamageMeasureDataWheel.LeftWheelDamageDistributedLoadValue != null ? wheelDamageMeasureDataWheel.LeftWheelDamageDistributedLoadValue : null,
                                            LeftWheelDamageMeanValue = wheelDamageMeasureDataWheel.LeftWheelDamageMeanValue != null ? wheelDamageMeasureDataWheel.LeftWheelDamageMeanValue : null,
                                            LeftWheelDamagePeakValue = wheelDamageMeasureDataWheel.LeftWheelDamagePeakValue != null ? wheelDamageMeasureDataWheel.LeftWheelDamagePeakValue : null,
                                            LeftWheelDamageQualityFactor = wheelDamageMeasureDataWheel.LeftWheelDamageQualityFactor != null ? wheelDamageMeasureDataWheel.LeftWheelDamageQualityFactor : null,
                                            RightWheelDamageDistributedLoadValue = wheelDamageMeasureDataWheel.RightWheelDamageDistributedLoadValue != null ? wheelDamageMeasureDataWheel.RightWheelDamageDistributedLoadValue : null,
                                            RightWheelDamageMeanValue = wheelDamageMeasureDataWheel.RightWheelDamageMeanValue != null ? wheelDamageMeasureDataWheel.RightWheelDamageMeanValue : null,
                                            RightWheelDamagePeakValue = wheelDamageMeasureDataWheel.RightWheelDamagePeakValue != null ? wheelDamageMeasureDataWheel.RightWheelDamagePeakValue : null,
                                            RightWheelDamageQualityFactor = wheelDamageMeasureDataWheel.RightWheelDamageQualityFactor != null ? wheelDamageMeasureDataWheel.RightWheelDamageQualityFactor : null,
                                            WheelDamageMeasureDataWheelId = wheelDamageMeasureDataWheel.WheelDamageMeasureDataWheelId
                                        });
                                    }
                                    //Sätt trainDTO till ett HJ meddelande (slarvigt)
                                    isWheelDamage = true;
                                }
                                #endregion
                            }
                        }

                        wheelList.Add(new WheelDTO()
                        {
                            WheelId = wheel.WheelId,
                            AlertList = alertListWheel,
                            HotBoxHotWheelMeasureWheelDataList = hotBoxHotWheelMeasureWheelDataList,
                            WheelDamageMeasureDataWheelList = wheelDamageMeasureDataWheelList
                        });
                    }

                    #region Wheel damage axle
                    var wheelDamageMeasureDataAxleList = new List<WheelDamageMeasureDataAxleDTO>();
                    if (axle.MeasurementValue != null && axle.MeasurementValue.Count() > 0)
                    {
                        foreach (var ax in axle.MeasurementValue)
                        {
                            if (ax.WheelDamageMeasureDataAxle != null && ax.WheelDamageMeasureDataAxle.Count() > 0)
                            {

                                foreach (var mv in ax.WheelDamageMeasureDataAxle)
                                {
                                    wheelDamageMeasureDataAxleList.Add(new WheelDamageMeasureDataAxleDTO()
                                    {
                                        AxleLoad = mv.AxleLoad,
                                        LeftRightLoadRatio = mv.LeftRightLoadRatio,
                                        WheelDamageMeasureDataAxleId = mv.WheelDamageMeasureDataAxleId
                                    });

                                }
                            }

                        }
                    }
                    #endregion

                    axleListDTO.Add(new AxleDTO()
                    {
                        AxleId = axle.AxleId,
                        AxleNumber = axle.AxleNumber,
                        AlertList = axleAlertList,
                        WheelList = wheelList,
                        WheelDamageMeasureDataAxleList = wheelDamageMeasureDataAxleList
                    });
                };
                #region WheelDamage Vehicle
                var wheelDamageMeasureDataVehicleList = new List<WheelDamageMeasureDataVehicleDTO>();
                if (vechicle.MeasurementValue != null && vechicle.MeasurementValue.Count() > 0)
                {
                    foreach (var mv in vechicle.MeasurementValue)
                    {
                        if (mv.WheelDamageMeasureDataVehicle != null && mv.WheelDamageMeasureDataVehicle.Count > 0)
                        {
                            foreach (var ve in mv.WheelDamageMeasureDataVehicle)
                            {
                                wheelDamageMeasureDataVehicleList.Add(new WheelDamageMeasureDataVehicleDTO()
                                {
                                    FrontRearLoadRatio = ve.FrontRearLoadRatio,
                                    LeftRightLoadRatio = ve.LeftRightLoadRatio,
                                    WeightInTons = ve.WeightInTons,
                                    WheelDamageMeasureDataVehicleId = ve.WheelDamageMeasureDataVehicleId
                                });

                            }
                        }
                    }
                }
                #endregion

                vehicleDTOList.Add(new VehicleDTO()
                {
                    VehicleId = vechicle.VehicleId,
                    AxleCount = vechicle.AxleCount.HasValue ? vechicle.AxleCount.Value : 0,
                    Speed = vechicle.Speed.HasValue ? vechicle.Speed.Value : 0,
                    VehicleNumber = vechicle.VehicleNumber,
                    AlertList = alertListVehicleDTO,
                    AxleList = axleListDTO,
                    WheelDamageMeasureDataVehicleList = wheelDamageMeasureDataVehicleList
                });
            }

            var trainDTO = new TrainDTO()
            {
                TrainId = train.TrainId,
                TrainDirection = train.TrainDirection.Name,
                TrainNumber = train.TrainNumber,
                TrainOperator = train.TrainOperator.Name,
                MessageSent = train.Message.SendTimeStamp.ToShortDateString(),
                Detector = train.Message.LocationId,
                isWheelDamage = isWheelDamage,
                isHotBoxHotWheel = isHotBoxHotWheel,
                Vehicles = vehicleDTOList,
                VehicleCount = train.VehicleCount.HasValue ? train.VehicleCount.Value : 0,
                AlertList = alertListDTOTrain,

            };
            return trainDTO;
        }

    }
}
