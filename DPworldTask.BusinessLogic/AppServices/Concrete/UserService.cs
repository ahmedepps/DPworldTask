using DPworldTask.BusinessLogic.AppServices.Interface;
using DPworldTask.DataAccess.Models;
using DPworldTask.DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPworldTask.BusinessLogic.AppServices.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _user;

        public UserService(IUserRepository<User> user)
        {
            _user = user;
        }
        public User GetUserByUserId(int userId)
        {
            try
            {
                return _user.GetById(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                return _user.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public User GetUserByUsername(string username)
        {
            try
            {
                return _user.GetByUsername(username);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public User GetByToken(string token)
        {
            try
            {
                return _user.GetByToken(token);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<User> AddUser(User User)
        {
            try
            {
                return await _user.Create(User);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool UpdateUser(User user)
        {
            try
            {
                _user.Update(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteUser(int userId)
        {

            try
            {
                var user = _user.GetById(userId);
                _user.Delete(user);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public User AuthenticateUser(string username, byte[] userPassword)
        {
            try
            {
                return _user.AuthenticateUser(username, userPassword);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
