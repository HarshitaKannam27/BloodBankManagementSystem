using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Service.Services
{
    public interface IUserService
    {
        public User Authenticate(string username, string password);
        public string Register(NewUserDto user);
        
        public User GetUserById(int id);
    }
}
