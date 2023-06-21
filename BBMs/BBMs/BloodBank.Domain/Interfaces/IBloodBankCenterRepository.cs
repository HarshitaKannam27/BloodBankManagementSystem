using BloodBank.Domain.Models;

namespace BloodBank.Domain.Interfaces
{
    public interface IBloodBankCenterRepository
    {
        public BloodBankCenter GetByLocation(string Location);
        public ICollection<BloodBankCenter> GetAllBloodBankCenter();
        public BloodBankCenter GetBloodBankCenterById(int Id);
        public bool AddBloodBankCenter(BloodBankCenter bloodBankCenter);
        public void DeleteBloodBankCenter(BloodBankCenter bloodBankId);
        public void UpdateBloodBankCenter(BloodBankCenter bloodBankCenter);
    }
}
