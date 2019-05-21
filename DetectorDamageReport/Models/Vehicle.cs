using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Axle = new HashSet<Axle>();
            WheelDamageMeasureDataVehicle = new HashSet<WheelDamageMeasureDataVehicle>();
        }

        public long VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public int? Speed { get; set; }
        public int? AxleCount { get; set; }
        public long MessageId { get; set; }

        public virtual Message Message { get; set; }
        public virtual ICollection<Axle> Axle { get; set; }
        public virtual ICollection<WheelDamageMeasureDataVehicle> WheelDamageMeasureDataVehicle { get; set; }
    }
}
