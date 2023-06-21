using BloodBank.DAL.Data;
using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DAL.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly BloodDbContext _dbcontext;
        public UserRepository(BloodDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public ICollection<User>GetAllUsers()
        {
            return _dbcontext.Users.OrderBy(x=>x.UserId).ToList();

        }
        public User GetUserByUsername(string username)
        {
            return _dbcontext.Users.FirstOrDefault(x => x.UserName == username);
        }

        public User GetUserById(int id)
        {
            return _dbcontext.Users.FirstOrDefault(x => x.UserId == id);
        }
       public string CreateUser(User user)
        {
            if (_dbcontext.Users.Add(user) != null)
            {
                _dbcontext.SaveChanges();
                return user.Token;
            }
            return null;
        }
    }
}
