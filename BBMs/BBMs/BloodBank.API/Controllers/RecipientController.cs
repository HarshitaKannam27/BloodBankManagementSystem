using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using BloodBank.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBank.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipientController : ControllerBase
    {
        private readonly IRecipientService _recipientService;
        private readonly ILogger<RecipientController> _logger;

        public RecipientController(IRecipientService recipientService,ILogger<RecipientController> logger)
        {
            _recipientService = recipientService;
            _logger = logger;

        }
        [HttpGet("GetRecipients")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Recipient>))]
        public IActionResult GetAllRecipients()
        {
            try
            {
                var Recipients = _recipientService.GetAllRecipients();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _logger.LogInformation("Recipients Fetched.");
                return Ok(Recipients);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while retrieving Recipients.");
                return StatusCode(500);
            }
        }
        [HttpGet("GetRecipientById")]
        public IActionResult GetRecipientById(int id)
        {
            try
            {
                var recipient = _recipientService.GetRecipientById(id);
                if (recipient == null)
                {
                    return NotFound();
                }
                _logger.LogInformation("Recipient are fetched by ID");
                return Ok(recipient);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving a Recipient by ID.");
                return StatusCode(500);
            }
        }
        [HttpPost("CreateRecipient")]
        public IActionResult CreateRecipient(RecipientDto recipient)
        {
            try
            {
                if (recipient == null)
                {
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!_recipientService.AddRecipient(recipient))
                {
                    ModelState.AddModelError("", "Recipient is not Created [CONTOLLER]");
                    return StatusCode(500, ModelState);
                }
                _logger.LogInformation("Recipient is Created");
                return Ok("Recipient Successfully Created");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating a Recipient.");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateRecipient")]
        public IActionResult UpdateRecipient(int id, Recipient recipient)
        {
            try
            {
                if (id != recipient.RecipientId)
                {
                    return BadRequest();
                }

                _recipientService.UpdateRecipient(recipient);
                _logger.LogInformation("Recipient is Created");

                return Ok("Recipient Successfully Updated");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating a Recipient.");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteRecipient")]
        public IActionResult DeleteRecipient(int id)
        {
            try
            {
                var recipient = _recipientService.GetRecipientById(id);

                if (recipient == null)
                {
                    return NotFound();
                }
                _recipientService.DeleteRecipient(recipient);
                _logger.LogInformation("Recipient is Deleted");

                return Ok("Recipient Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting a Recipient.");
                return StatusCode(500);
            }
        }
    }
}
