using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Service.Services
{
    public interface IBloodBankCenterService
    {
        public ICollection<BloodBankCenter> GetAllBloodBankCenters();
        BloodBankCenter GetBloodBankCenterById(int id);
        //public BloodBankCenter GetByCenter(string CenterName);
        public BloodBankCenter GetByLocation(string location);
        public bool AddBloodBankCenter(BloodBankCenterDto createBank);
        void DeleteBloodBankCenter(BloodBankCenter bloodBankCenter);
        void UpdateBloodBankCenter(BloodBankCenter bloodBankCenter);
    }
}
