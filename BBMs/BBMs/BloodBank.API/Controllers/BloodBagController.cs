using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using BloodBank.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBagController : ControllerBase
    {
        private readonly IBloodBagService _bloodBagService;
        private readonly ILogger<BloodBagController> _logger;

        public BloodBagController(IBloodBagService bloodBagService, ILogger<BloodBagController> logger)
        {
            _bloodBagService = bloodBagService;
            _logger = logger;
        }
        [HttpGet("GetBloodBag")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BloodBag>))]
        public IActionResult GetAllBloodBags()
        {
            try
            {
                var BloodBags = _bloodBagService.GetAllBloodBags();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _logger.LogInformation("BloodBag Fetched.");
                return Ok(BloodBags);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while retrieving BloodBag.");
                return StatusCode(500);
            }
        }
        [HttpGet("GetBloodBagById")]
        public IActionResult GetBloodBagById(int id)
        {
            try
            {
                var bloodBag = _bloodBagService.GetBloodBagById(id);
                if (bloodBag == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("BloodBag is fetched by ID");
                return Ok(bloodBag);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a BloodBag by ID.");
                return StatusCode(500);
            }
        }

        [HttpGet("BloodGroup")]
        public IActionResult GetBloodBagsByBloodGroup(string bloodGroup)
        {
            try
            {
                ICollection<BloodBagDto> bloodBagDTOs = _bloodBagService.GetBloodBagByBloodGroup(bloodGroup);
                return Ok(bloodBagDTOs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving blood bags by blood group.");
                return StatusCode(500, "An error occurred while processing the request.");
            }
        }

        [HttpPost("AddBloodBag")]
        public IActionResult AddBloodBag(BloodBagDto bloodBag)
        {
            try
            {
                if (bloodBag == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_bloodBagService.AddBloodBag(bloodBag))
                {
                    ModelState.AddModelError("", "BloodBag is not Created [CONTOLLER]");
                    return StatusCode(500, ModelState);
                }
                _logger.LogInformation("BloodBag is Created");
                return Ok("BloodBag Successfully Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a BloodBag.");
                return StatusCode(500);
            }
        }
        [HttpPut("UpdateBloodBag")]
        public IActionResult UpdateBloodBag(int id, BloodBag bloodBag)
        {
            try
            {
                if (id != bloodBag.BagId)
                {
                    return BadRequest();
                }
                _bloodBagService.UpdateBloodBag(bloodBag);
                _logger.LogInformation("BloodBag is Updated");
                return Ok("BloodBag Successfully Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a BloodBag.");
                return StatusCode(500);
            }
        }
        [HttpDelete("DeleteBloodBag")]
        public IActionResult DeleteBloodBag(int id)
        {
            try
            {
                var bloodBag = _bloodBagService.GetBloodBagById(id);
                if (bloodBag == null)
                {
                    return NotFound();
                }
                _bloodBagService.DeleteBloodBag(bloodBag);
                _logger.LogInformation("BloodBag is Deleted");
                return Ok("BloodBag Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a BloodBag");
                return StatusCode(500);
            }
        }
    }
}
