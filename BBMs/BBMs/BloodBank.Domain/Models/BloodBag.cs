using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BloodBank.Domain.Models
{
    public class BloodBag
    {
        [Key]
        public int BagId { get; set; }

        [Required]
        public string BloodGroup { get; set; }

        [Required]
        public int Quantity { get; set; }

        [ForeignKey("Donor")]
        public int DonorId { get; set; }

        [ForeignKey("BloodBankCenter")]
        public int BloodBankId { get; set; }

        public Donor? Donor { get; set; }
        public BloodBankCenter? BloodBankCenter { get; set; }
    }

}
