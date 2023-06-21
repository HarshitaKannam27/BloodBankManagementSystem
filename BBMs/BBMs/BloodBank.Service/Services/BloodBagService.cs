using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;

namespace BloodBank.Service.Services
{
    public class BloodBagService : IBloodBagService
    {
        private readonly IBloodBagRepository _bloodBagRepository;
        
        public BloodBagService(IBloodBagRepository bloodBagRepository)
        {
            _bloodBagRepository = bloodBagRepository;
            
        }

        public ICollection<BloodBag> GetAllBloodBags()
        {
            return _bloodBagRepository.GetAllBloodBags();
        }

        public BloodBag GetBloodBagById(int id)
        {
            return _bloodBagRepository.GetBloodBagById(id);

        }

        public ICollection<BloodBagDto> GetBloodBagByBloodGroup(string bloodGroup)
        {
            ICollection<BloodBag> bloodBags = _bloodBagRepository.GetBloodBagByBloodGroup(bloodGroup);

            ICollection<BloodBagDto> bloodBagDtos = new List<BloodBagDto>();
            foreach (BloodBag bloodBag in bloodBags)
            {
                BloodBagDto bloodBagDTO = new BloodBagDto
                {
                    BloodGroup = bloodBag.BloodGroup,
                    Quantity = bloodBag.Quantity
                };
                bloodBagDtos.Add(bloodBagDTO);
            }

            return bloodBagDtos;

        }
        public bool AddBloodBag(BloodBagDto createBag)
        {
            var temp = new BloodBag
            {
                BloodBankId=createBag.BloodBankId,
                DonorId=createBag.DonorId,
                BloodGroup = createBag.BloodGroup,
                Quantity = createBag.Quantity
            };
            var s=_bloodBagRepository.AddBloodBag(temp);
            if(s)
            {
                return true;
            }
            return false;
        }
        public void UpdateBloodBag(BloodBag bloodBag)
        {
            _bloodBagRepository.UpdateBloodBag(bloodBag);
        }

        public void DeleteBloodBag(BloodBag bloodBag)
        {
            _bloodBagRepository.DeleteBloodBag(bloodBag);
        }
     
    }
}
