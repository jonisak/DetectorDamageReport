using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Alert
    {
        public long AlertId { get; set; }
        public string MeasurementType { get; set; }
        public string DecriptionText { get; set; }
        public string AlarmCode { get; set; }
        public string AlarmLevel { get; set; }
        public long? TrainId { get; set; }
        public long? VehicleId { get; set; }
        public long? AxleId { get; set; }
        public long? WheelId { get; set; }

        public virtual Axle Axle { get; set; }
        public virtual Train Train { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Wheel Wheel { get; set; }
    }
}
