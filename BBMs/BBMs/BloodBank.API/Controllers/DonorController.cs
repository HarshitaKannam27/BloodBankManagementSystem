using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using BloodBank.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        private readonly ILogger<DonorController> _logger;

        public DonorController(IDonorService donorService, ILogger<DonorController> logger)
        {
            _donorService = donorService;
            _logger = logger;
        }
        [HttpGet("GetDonor")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Donor>))]
        public IActionResult GetAllDonors()
        {
            try
            {
                var Donors = _donorService.GetAllDonors();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _logger.LogInformation("Donors Fetched.");
                return Ok(Donors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while retrieving Donors.");
                return StatusCode(500);
            }
        }
        [HttpGet("GetDonorById")]
        public IActionResult GetDonorById(int id)
        {
            try
            {
                var donor = _donorService.GetDonorById(id);
                if (donor == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("Donor are fetched by ID");
                return Ok(donor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a Donor by ID.");
                return StatusCode(500);
            }
        }
        [HttpPost("AddDonor")]
        public IActionResult AddDonor(DonorDto donor)
        {
            try
            {
                if (donor == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_donorService.AddDonor(donor))
                {
                    ModelState.AddModelError("", "Donor is not Created [CONTOLLER]");
                    return StatusCode(500, ModelState);
                }
                _logger.LogInformation("Donor is Created");
                return Ok("Donor Successfully Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a Donor.");
                return StatusCode(500);
            }
        }
        [HttpPut("UpdateDonor")]
        public IActionResult UpdateDonor(int id, Donor donor)
        {
            try
            {
                if (id != donor.DonorId)
                {
                    return BadRequest();
                }
                _donorService.UpdateDonor(donor);
                _logger.LogInformation("Donor is Created");
                return Ok("Donor Successfully Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a Donor.");
                return StatusCode(500);
            }
        }
        [HttpDelete("DeleteDonor")]
        public IActionResult DeleteDonor(int id)
        {
            try
            {
                var donor = _donorService.GetDonorById(id);
                if (donor == null)
                {
                    return NotFound();
                }
                _donorService.DeleteDonor(donor);
                _logger.LogInformation("Donor is Deleted");
                return Ok("Donor Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a Donor");
                return StatusCode(500);
            }
        }
    }
}
