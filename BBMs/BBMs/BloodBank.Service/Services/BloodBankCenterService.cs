
using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;

namespace BloodBank.Service.Services
{
    public class BloodBankCenterService:IBloodBankCenterService
    {
        private readonly IBloodBankCenterRepository _bloodBankCenterRepository;
        
        public BloodBankCenterService(IBloodBankCenterRepository bloodBankCenterRepository)
        {
            _bloodBankCenterRepository = bloodBankCenterRepository;
           
        }

        public ICollection<BloodBankCenter> GetAllBloodBankCenters()
        {
            return _bloodBankCenterRepository.GetAllBloodBankCenter();
        }

        public BloodBankCenter GetBloodBankCenterById(int id)
        {
            return _bloodBankCenterRepository.GetBloodBankCenterById(id);

        }
        /* public BloodBankCenter GetByCenter(string CenterName)
         {
             return _bloodBankCenterRepository.GetByCenter(CenterName);
         }
        */
         public BloodBankCenter GetByLocation(string location)
         {
             return _bloodBankCenterRepository.GetByLocation(location);
         }
        public bool AddBloodBankCenter(BloodBankCenterDto createBank)
        {

            var temp = new BloodBankCenter
            {
                Location = createBank.Location,
                 CenterName=createBank.CenterName,
                
             };

            var s = _bloodBankCenterRepository.AddBloodBankCenter(temp);
            if(s)
            {
                return true;
            }
            return false;

        }
        public void UpdateBloodBankCenter(BloodBankCenter bloodBankCenter)
        {
            _bloodBankCenterRepository.UpdateBloodBankCenter(bloodBankCenter);
        }

        public void DeleteBloodBankCenter(BloodBankCenter bloodBankCenter)
        {
            _bloodBankCenterRepository.DeleteBloodBankCenter(bloodBankCenter);
        }
    }

}

