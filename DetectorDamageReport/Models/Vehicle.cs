using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Axle = new HashSet<Axle>();
            MeasurementValue = new HashSet<MeasurementValue>();
        }

        public long VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public int? Speed { get; set; }
        public int? AxleCount { get; set; }
        public long TrainId { get; set; }

        public virtual Train Train { get; set; }
        public virtual ICollection<Axle> Axle { get; set; }
        public virtual ICollection<MeasurementValue> MeasurementValue { get; set; }
    }
}
