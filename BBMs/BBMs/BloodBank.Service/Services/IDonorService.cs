using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;

namespace BloodBank.Service.Services
{
    public interface IDonorService
    {
        Donor GetDonorById(int id);
        public ICollection<Donor> GetAllDonors();
        bool AddDonor(DonorDto donor);
        void UpdateDonor(Donor donor);
        void DeleteDonor(Donor donor);
    }
}
