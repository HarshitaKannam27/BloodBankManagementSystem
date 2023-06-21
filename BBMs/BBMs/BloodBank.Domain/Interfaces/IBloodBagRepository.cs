using BloodBank.Domain.Models;

namespace BloodBank.Domain.Interfaces
{
    public interface IBloodBagRepository
    {
      public BloodBag? GetBloodBagById(int id);
        ICollection<BloodBag> GetBloodBagByBloodGroup(string bloodGroup);
        public ICollection<BloodBag> GetAllBloodBags();
       public bool AddBloodBag(BloodBag bloodBag);
       public void UpdateBloodBag(BloodBag bloodBag);
        public void DeleteBloodBag(BloodBag bloodBag);
    }
}
