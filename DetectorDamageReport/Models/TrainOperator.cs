using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class TrainOperator
    {
        public TrainOperator()
        {
            Message = new HashSet<Message>();
        }

        public int TrainOperatorId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Message> Message { get; set; }
    }
}
