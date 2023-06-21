using BloodBank.Domain.Models;

namespace BloodBank.Service.DTOs
{
    public class BloodBagDto
    {
        public string BloodGroup { get; set; }
        public int Quantity { get; set; }
        public int DonorId { get; set; }
        public int BloodBankId { get; set; }
        //public BloodBankCenter BloodBankCenter { get; set; }
    }
}
