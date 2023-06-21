using BloodBank.Domain.Models;

namespace BloodBank.Service.DTOs
{
    public class UserPasswordDto
    {
        public string Password { get; set; }

        public static explicit operator User(UserPasswordDto dto)
        {
            if (dto == null)
                return null;

            return new User
            {
                Password = dto.Password
            };
        }

        public static implicit operator UserPasswordDto(User user)
        {
            if (user == null)
                return null;

            return new UserPasswordDto
            {
                Password = user.Password
            };
        }
    }
}
