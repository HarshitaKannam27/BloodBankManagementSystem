using BloodBank.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Domain.Interfaces
{
    public interface IRecipientRepository
    {
        public Recipient? GetRecipientById(int RecipientId);
      public  ICollection<Recipient> GetAllRecipients();
      public  bool AddRecipient(Recipient recipient);
        public void UpdateRecipient(Recipient recipient);
        public  void DeleteRecipient(Recipient recipient);
    }
}
