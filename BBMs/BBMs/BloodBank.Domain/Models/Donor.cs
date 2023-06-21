using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodBank.Domain.Models
{
    public class Donor
    {
        [Key]
        public int DonorId { get; set; }
        [Required]
        [StringLength(50)]
        public string DonorName { get; set; }
        [Required]
        public string BloodGroup { get; set; }
        [Required]
        [Range(17,65)]
        public int Age { get; set; }
        
        [Required]
        public string Gender { get; set; }
        [Required]
        public string ContactNumber { get; set; }

        [ForeignKey("BloodBankCenter")]
        public int BloodBankId { get; set; }

        public BloodBankCenter? BloodBankCenter { get; set; }
    }
}
