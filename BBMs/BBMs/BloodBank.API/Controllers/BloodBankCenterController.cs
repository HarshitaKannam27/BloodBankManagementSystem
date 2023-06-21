using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using BloodBank.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodBankCenterController : ControllerBase
    {
        private readonly IBloodBankCenterService _bloodBankCenterService;
        private readonly ILogger<BloodBankCenterController> _logger;

        public BloodBankCenterController(IBloodBankCenterService bloodBankCenterService, ILogger<BloodBankCenterController> logger)
        {
            _bloodBankCenterService = bloodBankCenterService;
            _logger = logger;
        }
        [HttpGet("GetAllBloodBankCenters")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Donor>))]
        public IActionResult GetAllBloodBankCenters()
        {
            try
            {
                var bloodBankCenters = _bloodBankCenterService.GetAllBloodBankCenters();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _logger.LogInformation("BloodBankCenters Fetched.");
                return Ok(bloodBankCenters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while retrieving BloodBankCenters.");
                return StatusCode(500);
            }
        }
        [HttpGet("GetBloodBankCentersById")]
        public IActionResult GetDonorById(int id)
        {
            try
            {
                var bloodBankCenter = _bloodBankCenterService.GetBloodBankCenterById(id);
                if (bloodBankCenter == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("bloodBankCenter are fetched by ID");
                return Ok(bloodBankCenter);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a bloodBankCenter by ID.");
                return StatusCode(500);
            }
        }
        [HttpPost("AddBloodBankCenter")]
        public IActionResult AddBloodBankCenter(BloodBankCenterDto bloodBankCenter)
        {
            try
            {
                if (bloodBankCenter == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_bloodBankCenterService.AddBloodBankCenter(bloodBankCenter))
                {
                    ModelState.AddModelError("", "BloodBankCenter is not Created [CONTOLLER]");
                    return StatusCode(500, ModelState);
                }
                _logger.LogInformation("BloodBankCenter is Created");
                return Ok("BloodBankCenter Successfully Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a BloodBankCenter.");
                return StatusCode(500);
            }
        }


        [HttpPut("UpdateBloodBankCenter")]
        public IActionResult UpdateBloodBankCenter(int id, BloodBankCenter bloodBankCenter)
        {
            try
            {
                if (id != bloodBankCenter.BloodBankId)
                {
                    return BadRequest();
                }
                _bloodBankCenterService.UpdateBloodBankCenter(bloodBankCenter);
                _logger.LogInformation("BloodBankCenter is Created");
                return Ok("BloodBankCenter Successfully Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a BloodBankCenter.");
                return StatusCode(500);
            }
        }
        [HttpDelete("DeleteBloodBankCenter")]
        public IActionResult DeleteBloodBankCenter(int id)
        {
            try
            {
                var bloodBankCenter = _bloodBankCenterService.GetBloodBankCenterById(id);
                if (bloodBankCenter == null)
                {
                    return NotFound();
                }
                _bloodBankCenterService.DeleteBloodBankCenter(bloodBankCenter);
                _logger.LogInformation("BloodBankCenter is Deleted");
                return Ok("BloodBankCenter Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a BloodBankCenter");
                return StatusCode(500);
            }
        }
    }
}

