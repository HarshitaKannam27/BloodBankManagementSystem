using BloodBank.DAL.Data;
using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.DAL.Repository
{
    public class DonorRepository :IDonorRepository
    {
        private readonly BloodDbContext _dbContext;

        public DonorRepository(BloodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Donor? GetDonorById(int id)
        {
            return _dbContext.Donors.Include(x=>x.BloodBankCenter).FirstOrDefault(x => x.DonorId == id);
        }

        public ICollection<Donor> GetAllDonors()
        {
            return _dbContext.Donors.OrderBy(x=>x.DonorId).ToList();
        }

        public bool AddDonor(Donor donor)
        {
            if (_dbContext.Donors.Add(donor) != null)
            {
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateDonor(Donor donor)
        {
            _dbContext.Donors.Update(donor);
            _dbContext.SaveChanges();
        }

        public void DeleteDonor(Donor donor)
        {
            _dbContext.Donors.Remove(donor);
            _dbContext.SaveChanges();
        }
       

    }
}
