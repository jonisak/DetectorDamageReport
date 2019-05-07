using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DetectorDamageReport.Model
{
    public class DetectorDamageReportContext : DbContext
    {
        public DetectorDamageReportContext(DbContextOptions<DetectorDamageReportContext> options)
         : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
