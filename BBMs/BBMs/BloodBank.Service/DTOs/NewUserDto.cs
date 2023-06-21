using BloodBank.Domain.Models;

namespace BloodBank.Service.DTOs
{
    public class NewUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public static explicit operator User(NewUserDto dto)
        {
            if (dto == null)
                return null;

            return new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserName = dto.UserName,
                Password = dto.Password,
                IsAdmin = dto.IsAdmin
            };
        }

        public static implicit operator NewUserDto(User user)
        {
            if (user == null)
                return null;

            return new NewUserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                IsAdmin = user.IsAdmin
            };
        }
    }
}
