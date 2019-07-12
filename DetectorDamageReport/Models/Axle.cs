using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Axle
    {
        public Axle()
        {
            MeasurementValue = new HashSet<MeasurementValue>();
            Wheel = new HashSet<Wheel>();
        }

        public long AxleId { get; set; }
        public int? AxleNumber { get; set; }
        public long VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<MeasurementValue> MeasurementValue { get; set; }
        public virtual ICollection<Wheel> Wheel { get; set; }
    }
}
