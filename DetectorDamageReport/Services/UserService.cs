using DetectorDamageReport.Helpers;
using DetectorDamageReport.Models;
using DetectorDamageReport.Models.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DetectorDamageReport.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        //Task<IEnumerable<User>> GetAll();
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        //private List<User> _users = new List<User>
        //{
        //    new User { UserId = 1, UserName = "test", Password = "1111" }
        //};

        public async Task<User> Authenticate(string username, string password)
        {

            var user = await Task.Run(() => new UserManager().GetByUsername(username));

            //var user = await Task.Run(() => _users.SingleOrDefault(x => x.UserName == username && x.Password == password ));

            // return null if user not found
            if (user == null)
                return null;

            //string hashed_password = SecurePasswordHasherHelper.Hash(password);


            if (!SecurePasswordHasherHelper.Verify(password, user.Password))
            {
                return null;
            }

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }

        //public async Task<IEnumerable<User>> GetAll()
        //{
        //    // return users without passwords
        //    return await Task.Run(() => _users.Select(x => {
        //        x.Password = null;
        //        return x;
        //    }));
        //}
    }
}
