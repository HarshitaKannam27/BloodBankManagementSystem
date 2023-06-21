using BloodBank.Domain.Models;

namespace BloodBank.Service.DTOs
{
    public class DonorDto
    {
       
        public string DonorName { get; set; }
        public string BloodGroup { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string ContactNumber { get; set; }

        public int BloodBankId { get; set; }
       // public BloodBankCenter BloodBankCenter { get; set; }

        public static explicit operator Donor(DonorDto dto)
        {
            if(dto==null) return null;
            return new Donor
            {
                DonorName = dto.DonorName,
                BloodGroup = dto.BloodGroup,
                Age = dto.Age,
                Gender = dto.Gender,
                ContactNumber = dto.ContactNumber,
                BloodBankId = dto.BloodBankId
            };
        }
        public static implicit operator DonorDto(Donor donor)
        {
            if (donor == null)
                return null;

            return new DonorDto
            {
                DonorName = donor.DonorName,
                BloodGroup = donor.BloodGroup,
                Age = donor.Age,
                Gender = donor.Gender,
                ContactNumber = donor.ContactNumber,
                BloodBankId = donor.BloodBankId,
            };
        }

    }

}

