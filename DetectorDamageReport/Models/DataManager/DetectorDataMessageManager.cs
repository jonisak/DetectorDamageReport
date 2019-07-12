using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.Models.DataManager
{
    public class DetectorDataMessageManager
    {
        readonly DetectorDamageReportContext _detectorDamageReportContext;

        public DetectorDataMessageManager(DetectorDamageReportContext context)
        {
            _detectorDamageReportContext = context;
        }

        public DetectorDataMessageManager()
        {
            _detectorDamageReportContext = new DetectorDamageReportContext();
        }


        public void Add(DetectorDataMessage detectorDataMessage)
        {

            foreach (var item in _detectorDamageReportContext.Message.ToList())
            {
                _detectorDamageReportContext.Message.Remove(item);
            }
            _detectorDamageReportContext.SaveChanges();


            var message = new Message();
            message.MessageId = Convert.ToInt64(detectorDataMessage.Header.MessageID);
            message.Vendor = detectorDataMessage.Header.Vendor;
            message.SoftwareVersion = detectorDataMessage.Header.SoftwareVersion;
            message.SendTimeStamp = detectorDataMessage.Header.SendTimeStamp;
            message.LocationId = detectorDataMessage.Location.LocationID;
            message.CountryCode = detectorDataMessage.Location.CountryCode;
            message.Owner = detectorDataMessage.Location.Owner;
            message.Track = detectorDataMessage.Location.Track;
            _detectorDamageReportContext.Message.Add(message);

            var train = new Train();
            train.Message = message;
            var trainOperator = _detectorDamageReportContext.TrainOperator.Where(o => o.Name == detectorDataMessage.Train.Operator).FirstOrDefault();
            if (trainOperator == null)
            {
                train.TrainOperatorId = _detectorDamageReportContext.TrainOperator.Where(o => o.Name == "Okänt järnvägsföretag").FirstOrDefault().TrainOperatorId;
            }
            else
            {
                train.TrainOperatorId = _detectorDamageReportContext.TrainOperator.Where(o => o.Name == detectorDataMessage.Train.Operator).FirstOrDefault().TrainOperatorId;
            }


            if (detectorDataMessage.Train.TrainNumber != null)
            {
                train.TrainNumber = detectorDataMessage.Train.TrainNumber;
            }



            if (detectorDataMessage.Train.Direction == "2")
            {
                train.TrainDirectionId = 2;
            }
            else if (detectorDataMessage.Train.Direction == "1")
            {
                train.TrainDirectionId = 1;
            }
            else
            {
                train.TrainDirectionId = 3;
            }

            if (detectorDataMessage.Train.VehicleCount != null && detectorDataMessage.Train.VehicleCount.Length > 0)
            {
                train.VehicleCount = Convert.ToInt32(detectorDataMessage.Train.VehicleCount);
            }


            _detectorDamageReportContext.Train.Add(train);


            foreach (var trainVehicle in detectorDataMessage.Train.Vehicle)
            {
                var vehicle = new Vehicle();
                vehicle.VehicleNumber = trainVehicle.VehicleNumber;
                vehicle.Speed = Convert.ToInt32(trainVehicle.Speed);
                vehicle.AxleCount = Convert.ToInt32(trainVehicle.AxleCount);
                vehicle.Train = train;
                _detectorDamageReportContext.Vehicle.Add(vehicle);

                //Mätvärden på fordonsnivå
                if (trainVehicle.MeasurementValues != null && trainVehicle.MeasurementValues.Count() > 0)
                {
                    var mv = new MeasurementValue();
                    mv.Vehicle = vehicle;
                    foreach (var vme in trainVehicle.MeasurementValues)
                    {
                        if (vme.DeviceType == "WHEELDAMAGE")
                        {
                            mv.DeviceType.DeviceTypeId = _detectorDamageReportContext.DeviceType.Where(o => o.Name == vme.DeviceType).FirstOrDefault().DeviceTypeId;
                            mv.SoftwareVersion = vme.SoftwareVersion;
                            mv.HardwareVersion = vme.HardwareVersion;
                            mv.Vendor = vme.Vendor;

                            _detectorDamageReportContext.MeasurementValue.Add(mv);
                            if (vme.MeasurementData.WheelDamageMeasureDataVehicle != null)
                            {
                                foreach (var md in mv.WheelDamageMeasureDataVehicle)
                                {
                                    var wheelDamageMeasureDataVehicle = new WheelDamageMeasureDataVehicle();
                                    wheelDamageMeasureDataVehicle.MeasurementValue = mv;
                                    wheelDamageMeasureDataVehicle.FrontRearLoadRatio = md.FrontRearLoadRatio;
                                    wheelDamageMeasureDataVehicle.LeftRightLoadRatio = md.LeftRightLoadRatio;
                                    wheelDamageMeasureDataVehicle.WeightInTons = md.WeightInTons;
                                    _detectorDamageReportContext.WheelDamageMeasureDataVehicle.Add(wheelDamageMeasureDataVehicle);
                                }

                            }


                        }
                    }


                }

                //Loopa alla axlar
                foreach (var ax in trainVehicle.Axle)
                {
                    var axle = new Axle();
                    axle.Vehicle = vehicle;
                    _detectorDamageReportContext.Axle.Add(axle);
                    axle.AxleNumber = Convert.ToInt32(ax.AxleNumber);

                    foreach (var axmv in ax.MeasurementValues)
                    {

                        var mv = new MeasurementValue();
                        mv.Axle = axle;
                        _detectorDamageReportContext.MeasurementValue.Add(mv);
                        mv.SoftwareVersion = axmv.SoftwareVersion;
                        mv.HardwareVersion = axmv.HardwareVersion;
                        mv.Vendor = axmv.Vendor;
                        if (axmv.DeviceType == "WHEELDAMAGE")
                        {
                            mv.DeviceType.DeviceTypeId = _detectorDamageReportContext.DeviceType.Where(o => o.Name == axmv.DeviceType).FirstOrDefault().DeviceTypeId;
                        }


                    }


                    foreach (var we in ax.Wheel)
                    {
                        var wheel = new Wheel();
                        wheel.Axle = axle;
                        _detectorDamageReportContext.Wheel.Add(wheel);






                        foreach (var measurementValues in we.MeasurementValues)
                        {
                            if (measurementValues.DeviceType == "HOTBOXHOTWHEEL")
                            {
                                var hotBoxHotWheelMeasureWheelData = new HotBoxHotWheelMeasureWheelData();
                                hotBoxHotWheelMeasureWheelData.HotBoxLeftValue = Convert.ToInt32(measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotBoxLeftValue);
                                hotBoxHotWheelMeasureWheelData.HotBoxRightValue = Convert.ToInt32(measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotBoxRightValue);
                                hotBoxHotWheelMeasureWheelData.HotWheelLeftValue = Convert.ToInt32(measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotWheelLeftValue);
                                hotBoxHotWheelMeasureWheelData.HotWheelRightValue = Convert.ToInt32(measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotWheelRightValue);
                                hotBoxHotWheelMeasureWheelData.Wheel = wheel;
                                _detectorDamageReportContext.HotBoxHotWheelMeasureWheelData.Add(hotBoxHotWheelMeasureWheelData);

                            }
                        }
                        axle.Wheel.Add(wheel);


                    }


                    vehicle.Axle.Add(axle);

                }

            }

            _detectorDamageReportContext.SaveChanges();
        }

    }
}
