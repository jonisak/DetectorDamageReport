using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DetectorDamageReport.DTO;

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

        public List<TrainDTO> GetUserTrains(String userId)
        {
            // int uid = Convert.ToInt32(userId);

            //Ta fram en lista med användarens alla tågoperatörer
            var trainoperators = _detectorDamageReportContext.TrainOperatorUser.Where(o => o.User.UserName == userId).Select(o => o.TrainOperatorId).Distinct().ToList();

            var trains = _detectorDamageReportContext.Train
                               .Where(t => trainoperators.Contains(t.TrainOperatorId)).Take(4);



            List<TrainDTO> trainDTOs = new List<TrainDTO>();

            foreach (var train in trains)
            {
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

                var vehicleDTOList = new List<VehicleDTO>();
                foreach (var vechicle in train.Vehicle)
                {
                    #region larm Fordon
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
                    var axleListDTO = new List<AxleDTO>();
                    foreach (var axle in vechicle.Axle)
                    {
                        #region larm Axel
                        var axleAlertList = new List<AlertDTO>();
                        if (axle.Alert != null && axle.Alert.Count > 0)
                        {
                            foreach (var alertAxle in axle.Alert)
                            {
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
                        foreach (var wheel in axle.Wheel)
                        {
                            #region larm Hjul
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
                            if (wheel.MeasurementValue != null && wheel.MeasurementValue.Count > 0)
                            {
                                foreach (var measurementValue in wheel.MeasurementValue)
                                {
                                    #region Hot Box/Hot Wheel
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
                                    }
                                    #endregion
                                    #region Wheel Damage
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

                trainDTOs.Add(new TrainDTO()
                {
                    TrainId = train.TrainId,
                    TrainDirection = train.TrainDirection.Name,
                    TrainNumber = train.TrainNumber,
                    TrainOperator = train.TrainOperator.Name,
                    MessageSent = train.Message.SendTimeStamp.ToShortDateString(),
                    Detector = train.Message.LocationId,
                    Vehicles = vehicleDTOList,
                    VehicleCount = train.VehicleCount.HasValue ? train.VehicleCount.Value : 0,
                    AlertList = alertListDTOTrain
                });

            }
            return trainDTOs;
        }
    }
}
