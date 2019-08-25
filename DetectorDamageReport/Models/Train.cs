using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Train
    {
        public Train()
        {
            Alert = new HashSet<Alert>();
            Vehicle = new HashSet<Vehicle>();
        }

        public long TrainId { get; set; }
        public long MessageId { get; set; }
        public int TrainOperatorId { get; set; }
        public string TrainNumber { get; set; }
        public int TrainDirectionId { get; set; }
        public int? VehicleCount { get; set; }
        public bool TrainHasAlarms { get; set; }
        public bool IsWheelDamage { get; set; }
        public bool IsHotBoxHotWheel { get; set; }

        public virtual Message Message { get; set; }
        public virtual Traindirection TrainDirection { get; set; }
        public virtual TrainOperator TrainOperator { get; set; }
        public virtual ICollection<Alert> Alert { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
