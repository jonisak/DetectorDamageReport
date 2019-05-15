using DetectorDamageReport.Models.Repository;
using DetectorDamageReport.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.Models.DataManager
{
    public class UserManager : IDataRepository<User>
    {

        readonly DetectorDamageReportContext _detectorDamageReportContext;

        public UserManager(DetectorDamageReportContext context)
        {
            _detectorDamageReportContext = context;
        }

        public UserManager()
        {
            _detectorDamageReportContext = new DetectorDamageReportContext();
        }

        public IEnumerable<User> GetAll()
        {
            return _detectorDamageReportContext.User.ToList();
        }

        public User Get(long id)
        {
            return _detectorDamageReportContext.User
                  .FirstOrDefault(e => e.UserId == id);
        }
        public User GetByUsername(string username)
        {
            return _detectorDamageReportContext.User
                  .FirstOrDefault(e => e.UserName == username);
        }

        public void Add(User entity)
        {
            _detectorDamageReportContext.User.Add(entity);
            _detectorDamageReportContext.SaveChanges();
        }

        public void Update(User user, User entity)
        {
            user.UserName = entity.UserName;
            _detectorDamageReportContext.SaveChanges();
        }

        public void Delete(User user)
        {
            _detectorDamageReportContext.User.Remove(user);
            _detectorDamageReportContext.SaveChanges();
        }
    }
}
