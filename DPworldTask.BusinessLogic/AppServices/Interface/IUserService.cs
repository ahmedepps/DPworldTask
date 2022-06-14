using DPworldTask.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPworldTask.BusinessLogic.AppServices.Interface
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        bool DeleteUser(int userId);
        IEnumerable<User> GetAllUsers();
        User GetUserByUserId(int userId);
        User GetUserByUsername(string username);
        public User GetByToken(string token);
        bool UpdateUser(User user);
        public User AuthenticateUser(string username, byte[] userPassword);
    }

}
