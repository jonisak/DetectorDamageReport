using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Axle
    {
        public long AxleId { get; set; }
        public int? AxleNumber { get; set; }
        public long VehicleId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
