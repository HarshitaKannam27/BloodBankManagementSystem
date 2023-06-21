using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Service.Services
{
    public interface IRecipientService
    {
        Recipient GetRecipientById(int id);


       public ICollection<Recipient> GetAllRecipients();

        bool AddRecipient(RecipientDto recipient);

        void UpdateRecipient(Recipient recipient);
        void DeleteRecipient(Recipient recipient);
       
    }
}
