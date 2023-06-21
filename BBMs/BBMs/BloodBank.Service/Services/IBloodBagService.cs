using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Service.Services
{
    public interface IBloodBagService
    {
       public  ICollection<BloodBag> GetAllBloodBags();
        ICollection<BloodBagDto> GetBloodBagByBloodGroup(string bloodGroup);
        BloodBag GetBloodBagById(int id);
        bool AddBloodBag(BloodBagDto bloodBag);
        void UpdateBloodBag(BloodBag bloodBag);
        void DeleteBloodBag(BloodBag bloodBag);
    }
}
