using BloodBank.Domain.Models;

namespace BloodBank.Service.DTOs
{
    public class RecipientDto
    {
    
        public string RecipientName { get; set;}
        public string BloodGroup { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string ContactNumber { get; set; }
        public int BloodBankId { get; set; }

    }
}
