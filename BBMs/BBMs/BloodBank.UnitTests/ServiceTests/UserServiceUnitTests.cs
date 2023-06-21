using System.Text;
using BloodBank.Service.Services;
using Moq;
using BloodBank.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;

namespace BloodBank.UnitTests.Services
{
    [TestFixture]
    public class UserServiceUnitTests
    {

        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<IConfiguration> _configurationMock;
        private UserService _userService;

        [SetUp]
        public void Setup()
        {
            // Creating mock instances for dependencies
            _userRepositoryMock = new Mock<IUserRepository>();
            _configurationMock = new Mock<IConfiguration>();

            // Initializing the UserService with the mock dependencies
            _userService = new UserService(_userRepositoryMock.Object, _configurationMock.Object);
        }

        /*[Test]
        public void Authenticate_WithValidCredentials_ReturnsJwtToken()
        {
            // Arrange
            var username = "testuser";
            var password = "password";

            // Create a mock user with matching username and password
            var mockUser = new User
            {
                UserName = username,
                Password = _userService.CreatePasswordHash(password)
            };
            _userRepositoryMock.Setup(repo => repo.GetUserByUsername(username)).Returns(mockUser);

            // Mock the JWT configuration values
            _configurationMock.Setup(config => config["Jwt:Key"]).Returns("your_secret_key");
            _configurationMock.Setup(config => config["Jwt:Issuer"]).Returns("your_issuer");
            _configurationMock.Setup(config => config["Jwt:Audience"]).Returns("your_audience");

            // Act
            var jwtToken = _userService.Authenticate(username, password);

            // Assert
            Assert.That(jwtToken, Is.Not.Null);
            Assert.That(jwtToken, Is.Not.Empty);
        }*/

        [Test]
        public void Authenticate_WithValidCredentials_ReturnsJwtToken()
        {
            // Arrange
            var username = "testuser";
            var password = "password";

            // Create a mock user with matching username and password
            var mockUser = new User
            {
                UserName = username,
                Password = _userService.CreatePasswordHash(password)
            };
            _userRepositoryMock.Setup(repo => repo.GetUserByUsername(username)).Returns(mockUser);

            // Mock the JWT configuration values
            var validKey = Encoding.ASCII.GetBytes("Jwt:Key");
            _configurationMock.Setup(config => config["Jwt:Key"]).Returns(Convert.ToBase64String(validKey));
            _configurationMock.Setup(config => config["Jwt:Issuer"]).Returns("your_issuer");
            _configurationMock.Setup(config => config["Jwt:Audience"]).Returns("your_audience");

            // Act
            var jwtToken = _userService.Authenticate(username, password);

            // Assert
            Assert.That(jwtToken, Is.Not.Null);
            Assert.That(jwtToken, Is.Not.Empty);
        }


        [Test]
        public void Authenticate_WithInvalidCredentials_ReturnsNull()
        {
            // Arrange
            var username = "testuser";
            var password = "password";

            // Mock the GetUserByUsername method to return null, simulating invalid credentials
            _userRepositoryMock.Setup(repo => repo.GetUserByUsername(username)).Returns((User)null);

            // Act
            var jwtToken = _userService.Authenticate(username, password);

            // Assert
            Assert.That(jwtToken, Is.Null);
        }

        [Test]
        public void Register_ValidUser_ReturnsUserId()
        {
            // Arrange
            var newUser = new NewUserDto
            {
                FirstName = "John",
                LastName = "Doe",
                UserName = "johndoe",
                Password = "password",
                IsAdmin = false
            };

            // Mock the CreateUser method to return a userId
            _userRepositoryMock.Setup(repo => repo.CreateUser(It.IsAny<User>())).Returns("user123");

            // Act
            var result = _userService.Register(newUser);

            // Assert
            Assert.That(result, Is.EqualTo("user123"));
        }
    }
}
    

