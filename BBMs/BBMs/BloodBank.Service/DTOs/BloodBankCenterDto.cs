using BloodBank.Domain.Models;

namespace BloodBank.Service.DTOs
{
    public class BloodBankCenterDto
    {
        
        public string CenterName { get; set; }
        public string Location { get; set; }


        public static implicit operator BloodBankCenterDto(BloodBankCenter bloodbankcenter)
        {
            return new BloodBankCenterDto
            {
                CenterName = bloodbankcenter.CenterName,
                Location = bloodbankcenter.Location,
               
            };
        }

        public static explicit operator BloodBankCenter(BloodBankCenterDto dto)
        {
            return new BloodBankCenter
            {
                CenterName = dto.CenterName,
                Location = dto.Location,
                
            };
        }
    }
}
