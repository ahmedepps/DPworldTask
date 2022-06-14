using DPworldTask.DataAccess.Data;
using DPworldTask.DataAccess.Models;
using DPworldTask.DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPworldTask.DataAccess.Repositories.Concrete
{
    public class UserRepository : IUserRepository<User>
    {
        ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _dbContext = applicationDbContext;
        }
        public IEnumerable<User> GetAll()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public User GetById(int Id)
        {
            try
            {
                return _dbContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<User> Create(User _object)
        {
            var obj = await _dbContext.Users.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }
        public void Update(User _object)
        {
            _dbContext.Users.Update(_object);
            _dbContext.SaveChanges();
        }
        public void Delete(User _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }
        public User GetByUsername(string username)
        {
            return _dbContext.Users.Where(x =>  x.Username == username).FirstOrDefault();
        }
        public User GetByToken(string token)
        {
            return _dbContext.Users.Where(x => x.RefreshToken == token).FirstOrDefault();
        }

        public User AuthenticateUser(string username, byte[] userPassword)
        {

            return _dbContext.Users.Where(x =>  x.Username == username
            && x.PasswordHash == userPassword).FirstOrDefault();

        }
    }

}
