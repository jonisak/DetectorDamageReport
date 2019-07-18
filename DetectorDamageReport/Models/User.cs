using System;
using System.Collections.Generic;

namespace DetectorDamageReport.Models
{
    public partial class User
    {
        public User()
        {
            TrainOperatorUser = new HashSet<TrainOperatorUser>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<TrainOperatorUser> TrainOperatorUser { get; set; }
    }
}
