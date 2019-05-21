using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class Message
    {
        public Message()
        {
            Vehicle = new HashSet<Vehicle>();
        }

        public long MessageId { get; set; }
        public DateTime SendTimeStamp { get; set; }
        public string LocationId { get; set; }
        public string CountryCode { get; set; }
        public string Owner { get; set; }
        public string Track { get; set; }
        public int TrainOperatorId { get; set; }
        public string TrainNumber { get; set; }
        public int TrainDirectionId { get; set; }

        public virtual Traindirection TrainDirection { get; set; }
        public virtual TrainOperator TrainOperator { get; set; }
        public virtual ICollection<Vehicle> Vehicle { get; set; }
    }
}
