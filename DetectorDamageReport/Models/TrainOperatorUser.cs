using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class TrainOperatorUser
    {
        public int UserId { get; set; }
        public int TrainOperatorId { get; set; }

        public virtual TrainOperator TrainOperator { get; set; }
        public virtual User User { get; set; }
    }
}
