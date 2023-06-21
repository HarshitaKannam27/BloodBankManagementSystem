using BloodBank.Domain.Models;

namespace BloodBank.Domain.Interfaces
{
    public interface IDonorRepository
    {
        public Donor? GetDonorById(int Donorid);
        public ICollection<Donor> GetAllDonors();
       public bool AddDonor(Donor donor);
       public void UpdateDonor(Donor donor);
        public void DeleteDonor(Donor donor);
    }
}
