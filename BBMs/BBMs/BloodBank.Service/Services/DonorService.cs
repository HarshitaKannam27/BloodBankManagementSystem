
using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;

namespace BloodBank.Service.Services
{
    public class DonorService:IDonorService
    {
        private readonly IDonorRepository _donorRepository;
        
        public DonorService(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
           
        }
        public ICollection<Donor> GetAllDonors()
        {
            return _donorRepository.GetAllDonors();
        }

       
        public Donor GetDonorById(int id)
        {
            return _donorRepository.GetDonorById(id);
        }
        public bool AddDonor(DonorDto createDonor)
        {

            var temp = new Donor
            {
                DonorName = createDonor.DonorName,
                Age = createDonor.Age,
                BloodGroup = createDonor.BloodGroup,
                ContactNumber = createDonor.ContactNumber,
                Gender = createDonor.Gender,
                BloodBankId=createDonor.BloodBankId,
            };
            var s = _donorRepository.AddDonor(temp);
            if (s)
            {
                return true;
            }
            return false;

        }
        public void DeleteDonor(Donor donor)
        {
            _donorRepository.DeleteDonor(donor);
        }
        public void UpdateDonor(Donor newDonor)
        {
            _donorRepository.UpdateDonor(newDonor);
        }
       
    }

}

