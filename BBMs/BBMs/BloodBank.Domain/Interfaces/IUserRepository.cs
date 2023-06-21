using BloodBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Domain.Interfaces
{
    public interface IUserRepository
    {
       public User GetUserByUsername(string username);
        public User GetUserById(int UserId);
        public string CreateUser(User user);
    }
}
