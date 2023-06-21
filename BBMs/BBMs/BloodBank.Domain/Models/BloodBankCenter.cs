using System.ComponentModel.DataAnnotations;

namespace BloodBank.Domain.Models
{
    public class BloodBankCenter
    {
        [Key]
        public int BloodBankId { get; set; }
        [Required]
        public string CenterName { get; set; }

        [Required]
        public string  Location { get; set; }

        
    }
}
