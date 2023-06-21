using BloodBank.DAL.Data;
using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;

namespace BloodBank.DAL.Repository
{
    public class BloodBankCenterRepository : IBloodBankCenterRepository
    {
        private readonly BloodDbContext _dbContext;

        public BloodBankCenterRepository(BloodDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public BloodBankCenter GetByLocation(string location)
        {
            return _dbContext.BloodBankCenters.Where(x => x.Location == location).FirstOrDefault(); ;
        }


        public ICollection<BloodBankCenter> GetAllBloodBankCenter()
        {
            return _dbContext.BloodBankCenters.OrderBy(x=>x.BloodBankId).ToList();
        }
        
        public BloodBankCenter GetBloodBankCenterById(int Id)
        {
            return _dbContext.BloodBankCenters.Where(x => x.BloodBankId == Id).FirstOrDefault();
        }
            public bool AddBloodBankCenter(BloodBankCenter bloodBankCenter)
        {
            if ((_dbContext.BloodBankCenters.Add(bloodBankCenter)) != null)
            {
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public void DeleteBloodBankCenter(BloodBankCenter bloodBankId)
        {
            _dbContext.BloodBankCenters.Remove(bloodBankId);
            _dbContext.SaveChanges();
        }

        public void UpdateBloodBankCenter(BloodBankCenter bloodBankCenter)
        {
            _dbContext.BloodBankCenters.Update(bloodBankCenter);
            _dbContext.SaveChanges();
        }
        
    }
}
