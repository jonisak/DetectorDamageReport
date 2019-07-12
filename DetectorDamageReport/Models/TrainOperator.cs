using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class TrainOperator
    {
        public TrainOperator()
        {
            Train = new HashSet<Train>();
        }

        public int TrainOperatorId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Train> Train { get; set; }
    }
}
