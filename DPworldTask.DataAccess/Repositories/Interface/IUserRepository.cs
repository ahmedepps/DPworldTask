using DPworldTask.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPworldTask.DataAccess.Repositories.Interface
{
    public interface IUserRepository<T>
    {
        public Task<T> Create(T _object);

        public void Update(T _object);

        public IEnumerable<T> GetAll();

        public T GetById(int Id);

        public T GetByUsername(string username);

        public User GetByToken(string token);
     
        public void Delete(T _object);

        User AuthenticateUser(string username, byte[] userPassword);
    }
}
