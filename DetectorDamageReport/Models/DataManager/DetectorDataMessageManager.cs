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

            //foreach (var item in _detectorDamageReportContext.Message.ToList())
            //{
            //    _detectorDamageReportContext.Message.Remove(item);
            //}
            //_detectorDamageReportContext.SaveChanges();
            long mID = Convert.ToInt64(detectorDataMessage.Header.MessageID);
            if (_detectorDamageReportContext.Message.Where(o => o.MessageId == mID).Count() > 0)
            {
                return;
            }

            var message = new Message();
            message.MessageId = Convert.ToInt64(detectorDataMessage.Header.MessageID);
            message.Vendor = detectorDataMessage.Header.Vendor;
            message.SoftwareVersion = detectorDataMessage.Header.SoftwareVersion;
            message.SendTimeStamp = detectorDataMessage.Header.SendTimeStamp;
            message.LocationId = detectorDataMessage.Location.LocationID;


            var detector = _detectorDamageReportContext.Detector.Where(o => o.Sgln == detectorDataMessage.Location.LocationID).FirstOrDefault();

            if (detector != null)
            {
                message.Detector = detector;
            }

            message.CountryCode = detectorDataMessage.Location.CountryCode;
            message.Owner = detectorDataMessage.Location.Owner;
            message.Track = detectorDataMessage.Location.Track;
            message.ImportedTimeStamp = DateTime.Now;



            _detectorDamageReportContext.Message.Add(message);

            var train = new Train();
            train.IsHotBoxHotWheel = false;
            train.IsWheelDamage = false;
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
            #region Tågriktning
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
            #endregion
            if (detectorDataMessage.Train.VehicleCount != null && detectorDataMessage.Train.VehicleCount.Length > 0)
            {
                train.VehicleCount = Convert.ToInt32(detectorDataMessage.Train.VehicleCount);
            }
            #region Larm på tågnivå
            if (detectorDataMessage.Train.Alert != null)
            {

                foreach (var al in detectorDataMessage.Train.Alert)
                {
                    var alert = new Alert();
                    alert.Train = train;
                    alert.AlarmCode = al.AlarmCode;
                    alert.AlarmLevel = al.Level;
                    alert.DecriptionText = al.DecriptionText;
                    _detectorDamageReportContext.Alert.Add(alert);
                    train.TrainHasAlarms = true;

                }
            }
            #endregion

            _detectorDamageReportContext.Train.Add(train);

            foreach (var trainVehicle in detectorDataMessage.Train.Vehicle)
            {
                var vehicle = new Vehicle();
                vehicle.VehicleNumber = trainVehicle.VehicleNumber;
                vehicle.Speed = Convert.ToInt32(trainVehicle.Speed);
                vehicle.AxleCount = Convert.ToInt32(trainVehicle.AxleCount);
                vehicle.Train = train;
                _detectorDamageReportContext.Vehicle.Add(vehicle);

                if (trainVehicle.Alert != null)
                {

                    foreach (var al in trainVehicle.Alert)
                    {
                        var alert = new Alert();
                        alert.Vehicle = vehicle;
                        alert.MeasurementType = al.MeasurementType;
                        alert.AlarmCode = al.AlarmCode;
                        alert.AlarmLevel = al.Level;
                        alert.DecriptionText = al.DecriptionText;
                        _detectorDamageReportContext.Alert.Add(alert);
                        train.TrainHasAlarms = true;

                    }
                }




                #region Mätvärden fordonsnivå (aka hjulskador)
                //Mätvärden på fordonsnivå
                if (trainVehicle.MeasurementValues != null && trainVehicle.MeasurementValues.Count() > 0)
                {
                    var mv = new MeasurementValue();
                    mv.Vehicle = vehicle;
                    foreach (var vme in trainVehicle.MeasurementValues)
                    {
                        mv.DeviceType = _detectorDamageReportContext.DeviceType.Where(o => o.Name == vme.DeviceType).FirstOrDefault();
                        mv.SoftwareVersion = vme.SoftwareVersion;
                        mv.HardwareVersion = vme.HardwareVersion;
                        mv.Vendor = vme.Vendor;
                        _detectorDamageReportContext.MeasurementValue.Add(mv);

                        if (vme.DeviceType == "WHEELDAMAGE")
                        {
                            if (vme.MeasurementData.WheelDamageMeasureDataVehicle != null)
                            {

                                var wheelDamageMeasureDataVehicle = new WheelDamageMeasureDataVehicle();
                                wheelDamageMeasureDataVehicle.MeasurementValue = mv;
                                wheelDamageMeasureDataVehicle.FrontRearLoadRatio = vme.MeasurementData.WheelDamageMeasureDataVehicle.FrontRearLoadRatio;
                                wheelDamageMeasureDataVehicle.LeftRightLoadRatio = vme.MeasurementData.WheelDamageMeasureDataVehicle.LeftRightLoadRatio;
                                wheelDamageMeasureDataVehicle.WeightInTons = vme.MeasurementData.WheelDamageMeasureDataVehicle.WeightInTons;
                                _detectorDamageReportContext.WheelDamageMeasureDataVehicle.Add(wheelDamageMeasureDataVehicle);
                                train.IsWheelDamage = true;
                            }
                        }
                    }
                }

                #endregion

                //Loopa alla axlar
                foreach (var ax in trainVehicle.Axle)
                {
                    var axle = new Axle();
                    axle.Vehicle = vehicle;
                    _detectorDamageReportContext.Axle.Add(axle);
                    axle.AxleNumber = Convert.ToInt32(ax.AxleNumber);

                    if (ax.Alert != null)
                    {

                        foreach (var al in ax.Alert)
                        {
                            var alert = new Alert();
                            alert.Axle = axle;
                            alert.MeasurementType = al.MeasurementType;
                            alert.AlarmCode = al.AlarmCode;
                            alert.AlarmLevel = al.Level;
                            alert.DecriptionText = al.DecriptionText;
                            _detectorDamageReportContext.Alert.Add(alert);
                            train.TrainHasAlarms = true;

                        }
                    }

                    if (ax.MeasurementValues != null)
                    {
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
                                mv.DeviceType = _detectorDamageReportContext.DeviceType.Where(o => o.Name == axmv.DeviceType).FirstOrDefault();
                                var wheelDamageMeasureDataAxle = new WheelDamageMeasureDataAxle();
                                wheelDamageMeasureDataAxle.AxleLoad = axmv.MeasurementData.WheelDamageMeasureDataAxle.AxleLoad;
                                wheelDamageMeasureDataAxle.LeftRightLoadRatio = axmv.MeasurementData.WheelDamageMeasureDataAxle.LeftRightLoadRatio;
                                wheelDamageMeasureDataAxle.MeasurementValue = mv;
                                _detectorDamageReportContext.WheelDamageMeasureDataAxle.Add(wheelDamageMeasureDataAxle);
                                train.IsWheelDamage = true;
                            }
                        }
                    }



                    foreach (var we in ax.Wheel)
                    {
                        var wheel = new Wheel();
                        wheel.Axle = axle;
                        _detectorDamageReportContext.Wheel.Add(wheel);
                        if (we.Alert != null)
                        {

                            foreach (var al in we.Alert)
                            {
                                var alert = new Alert();
                                alert.Wheel = wheel;
                                alert.MeasurementType = al.MeasurementType;
                                alert.AlarmCode = al.AlarmCode;
                                alert.AlarmLevel = al.Level;
                                alert.DecriptionText = al.DecriptionText;
                                _detectorDamageReportContext.Alert.Add(alert);
                                train.TrainHasAlarms = true;

                            }
                        }


                        foreach (var measurementValues in we.MeasurementValues)
                        {
                            var mv = new MeasurementValue();
                            mv.SoftwareVersion = measurementValues.SoftwareVersion;
                            mv.HardwareVersion = measurementValues.HardwareVersion;
                            mv.Vendor = measurementValues.Vendor;
                            mv.DeviceType = _detectorDamageReportContext.DeviceType.Where(o => o.Name == measurementValues.DeviceType).FirstOrDefault();
                            mv.Wheel = wheel;
                            if (measurementValues.DeviceType == "HOTBOXHOTWHEEL")
                            {
                                var hotBoxHotWheelMeasureWheelData = new HotBoxHotWheelMeasureWheelData();
                                if (measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotBoxLeftValueSpecified)
                                {
                                    hotBoxHotWheelMeasureWheelData.HotBoxLeftValue = Convert.ToInt32(measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotBoxLeftValue);
                                }

                                if (measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotBoxRightValueSpecified)
                                {
                                    hotBoxHotWheelMeasureWheelData.HotBoxRightValue = Convert.ToInt32(measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotBoxRightValue);
                                }

                                if (measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotWheelLeftValueSpecified)
                                {
                                    hotBoxHotWheelMeasureWheelData.HotWheelLeftValue = Convert.ToInt32(measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotWheelLeftValue);
                                }
                                if (measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotWheelRightValueSpecified)
                                {
                                    hotBoxHotWheelMeasureWheelData.HotWheelRightValue = Convert.ToInt32(measurementValues.MeasurementData.HotBoxHotWheelMeasureWheelData.HotWheelRightValue);
                                }

                                hotBoxHotWheelMeasureWheelData.MeasurementValue = mv;
                                _detectorDamageReportContext.HotBoxHotWheelMeasureWheelData.Add(hotBoxHotWheelMeasureWheelData);
                                train.IsHotBoxHotWheel = true;
                            }
                            else if (measurementValues.DeviceType == "WHEELDAMAGE")
                            {
                                var wheelDamageMeasureDataWheel = new WheelDamageMeasureDataWheel();

                                if (measurementValues.MeasurementData.WheelDamageMeasureDataWheel.LeftWheelDamageDistributedLoadValueSpecified)
                                {
                                    wheelDamageMeasureDataWheel.LeftWheelDamageDistributedLoadValue = measurementValues.MeasurementData.WheelDamageMeasureDataWheel.LeftWheelDamageDistributedLoadValue;
                                }
                                if (measurementValues.MeasurementData.WheelDamageMeasureDataWheel.LeftWheelDamageMeanValueSpecified)
                                {
                                    wheelDamageMeasureDataWheel.LeftWheelDamageMeanValue = measurementValues.MeasurementData.WheelDamageMeasureDataWheel.LeftWheelDamageMeanValue;
                                }

                                if (measurementValues.MeasurementData.WheelDamageMeasureDataWheel.LeftWheelDamagePeakValueSpecified)
                                {
                                    wheelDamageMeasureDataWheel.LeftWheelDamagePeakValue = measurementValues.MeasurementData.WheelDamageMeasureDataWheel.LeftWheelDamagePeakValue;
                                }

                                if (measurementValues.MeasurementData.WheelDamageMeasureDataWheel.LeftWheelDamageQualityFactorSpecified)
                                {
                                    wheelDamageMeasureDataWheel.LeftWheelDamageQualityFactor = measurementValues.MeasurementData.WheelDamageMeasureDataWheel.LeftWheelDamageQualityFactor;
                                }

                                if (measurementValues.MeasurementData.WheelDamageMeasureDataWheel.RightWheelDamageDistributedLoadValueSpecified)
                                {
                                    wheelDamageMeasureDataWheel.RightWheelDamageDistributedLoadValue = measurementValues.MeasurementData.WheelDamageMeasureDataWheel.RightWheelDamageDistributedLoadValue;
                                }
                                if (measurementValues.MeasurementData.WheelDamageMeasureDataWheel.RightWheelDamageMeanValueSpecified)
                                {
                                    wheelDamageMeasureDataWheel.RightWheelDamageMeanValue = measurementValues.MeasurementData.WheelDamageMeasureDataWheel.RightWheelDamageMeanValue;
                                }
                                if (measurementValues.MeasurementData.WheelDamageMeasureDataWheel.RightWheelDamagePeakValueSpecified)
                                {
                                    wheelDamageMeasureDataWheel.RightWheelDamagePeakValue = measurementValues.MeasurementData.WheelDamageMeasureDataWheel.RightWheelDamagePeakValue;
                                }
                                if (measurementValues.MeasurementData.WheelDamageMeasureDataWheel.RightWheelDamageQualityFactorSpecified)
                                {
                                    wheelDamageMeasureDataWheel.RightWheelDamageQualityFactor = measurementValues.MeasurementData.WheelDamageMeasureDataWheel.RightWheelDamageQualityFactor;
                                }
                                wheelDamageMeasureDataWheel.MeasurementValue = mv;
                                _detectorDamageReportContext.WheelDamageMeasureDataWheel.Add(wheelDamageMeasureDataWheel);
                                train.IsWheelDamage = true;

                            }
                            _detectorDamageReportContext.MeasurementValue.Add(mv);

                        }



                        //axle.Wheel.Add(wheel);
                    }
                    //vehicle.Axle.Add(axle);
                }
            }



            _detectorDamageReportContext.SaveChanges();
        }


    }
}
