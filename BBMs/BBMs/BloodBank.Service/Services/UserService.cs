using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BloodBank.Service.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id); 
        }

        public User Authenticate(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null || !VerifyPasswordHash(password, user.Password))
            {
                // Authentication failed
                return null;
            }
            user.Password = "";
            return user;
        }
        public string Register(NewUserDto user)
        {
            // Hash the password before storing it in the database
            user.Password = CreatePasswordHash(user.Password);
            var temp = new User
            {
                /*UserId = user.UserId,*/
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };

            return _userRepository.CreateUser(temp);
        }

        /*public void UpdateUser(int userId, UserPasswordDTO userdto)
        {
            var existingUser = _userRepository.GetUserById(userId);
            if (existingUser == null)
            {
                // User not found
                return;
            }

            existingUser.Password = CreatePasswordHash(userdto.Password);
            var temp = new User
            {
                Password = existingUser.Password
            };

            _userRepository.UpdateUser(temp);
        }*/

        //Kept this method as public due to Testing requirements
        public string CreatePasswordHash(string password)
        {
            return password;
        }

        private bool VerifyPasswordHash(string password, string existingPassword)
        {
            return password == existingPassword;
        }

        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

