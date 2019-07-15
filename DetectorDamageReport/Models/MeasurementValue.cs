using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class MeasurementValue
    {
        public MeasurementValue()
        {
            HotBoxHotWheelMeasureWheelData = new HashSet<HotBoxHotWheelMeasureWheelData>();
            WheelDamageMeasureDataAxle = new HashSet<WheelDamageMeasureDataAxle>();
            WheelDamageMeasureDataVehicle = new HashSet<WheelDamageMeasureDataVehicle>();
            WheelDamageMeasureDataWheel = new HashSet<WheelDamageMeasureDataWheel>();
        }

        public long MeasurementValueId { get; set; }
        public int DeviceTypeId { get; set; }
        public string SoftwareVersion { get; set; }
        public string HardwareVersion { get; set; }
        public string Vendor { get; set; }
        public long? VehicleId { get; set; }
        public long? AxleId { get; set; }
        public long? WheelId { get; set; }

        public virtual Axle Axle { get; set; }
        public virtual DeviceType DeviceType { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Wheel Wheel { get; set; }
        public virtual ICollection<HotBoxHotWheelMeasureWheelData> HotBoxHotWheelMeasureWheelData { get; set; }
        public virtual ICollection<WheelDamageMeasureDataAxle> WheelDamageMeasureDataAxle { get; set; }
        public virtual ICollection<WheelDamageMeasureDataVehicle> WheelDamageMeasureDataVehicle { get; set; }
        public virtual ICollection<WheelDamageMeasureDataWheel> WheelDamageMeasureDataWheel { get; set; }
    }
}
