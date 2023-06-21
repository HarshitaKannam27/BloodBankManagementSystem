using BloodBank.DAL.Data;
using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.DAL.Repository
{
    public class BloodBagRepository : IBloodBagRepository
    {
        private readonly BloodDbContext _dbContext;
        public BloodBagRepository(BloodDbContext dbContext)
        {
            _dbContext= dbContext;
        }
        public bool AddBloodBag(BloodBag bloodBag)
        {
            if ((_dbContext.BloodBags.Add(bloodBag)) != null)
            {
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public ICollection<BloodBag> GetAllBloodBags()
        {
            return _dbContext.BloodBags.Include(x=>x.Donor).Include(x=>x.BloodBankCenter).OrderBy(x => x.BagId).ToList();
        }

       public BloodBag? GetBloodBagById(int id)
        {
            return _dbContext.BloodBags.Include(x=>x.BloodBankCenter).Include(x=>x.Donor).FirstOrDefault(x => x.BagId == id);
        }

        public ICollection<BloodBag> GetBloodBagByBloodGroup(string bloodGroup)
        {
            return _dbContext.BloodBags
                .Where(b => b.BloodGroup == bloodGroup)
                .ToList();
        }

        public void UpdateBloodBag(BloodBag bloodBag)
        {
            _dbContext.BloodBags.Update(bloodBag);
            _dbContext.SaveChanges();
        }

        public void DeleteBloodBag(BloodBag bloodBag)
        {
            _dbContext.BloodBags.Remove(bloodBag);
            _dbContext.SaveChanges();
        }
       
        
    }
}
