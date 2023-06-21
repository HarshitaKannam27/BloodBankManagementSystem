using BloodBank.Service.DTOs;
using BloodBank.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger) 
        {
            _userService = userService;
            _logger = logger;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.GetUserById(id);
                if (user == null)
                    return NotFound();

                _logger.LogInformation("User Fetched by Id.");
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving an User.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to retrieve user with ID: {id}.");
            }
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Authenticate(UserDto userdto)
        {
            try
            {
                var user = _userService.Authenticate(userdto.UserName, userdto.Password);
                if (user == null)
                {
                    // Authentication failed
                    return Unauthorized();
                }
               _logger.LogInformation("User Logged In & Token generated.");
                return Ok(new {
                    name=user.FirstName+" "+user.LastName,
                    id=user.UserId,
                    role=user.IsAdmin ? "Admin":"Donor"
                });
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "An error occurred while Login an User.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to create user.{ex}");
            }
        }

        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(NewUserDto model)
        {
            try
            {
                var user = new NewUserDto
                {
                    /*UserId = model.UserId,*/
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Password = model.Password,
                    IsAdmin = model.IsAdmin
                };

                _userService.Register(user);
                _logger.LogInformation("User successfully registered.");
                return Ok("User Successfully Registered");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while registering an User.");
                return StatusCode(StatusCodes.Status500InternalServerError, $"Failed to create user.{ex}");
            }
        }


    }
}
