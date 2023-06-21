using BloodBank.DAL.Data;
using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.DAL.Repository
{
    public class RecipientRepository:IRecipientRepository
    {
        private readonly BloodDbContext _dbContext;

        public RecipientRepository(BloodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Recipient? GetRecipientById(int id)
        {
            return _dbContext.Recipients.Include(x=>x.BloodBankCenter).FirstOrDefault(x => x.RecipientId == id);
        }

        public ICollection<Recipient> GetAllRecipients()
        {
            return _dbContext.Recipients.OrderBy(x=>x.RecipientId).ToList();
        }

        public bool AddRecipient(Recipient recipient)
        {
            if (_dbContext.Recipients.Add(recipient) != null)
            {
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateRecipient(Recipient recipient)
        {
            _dbContext.Recipients.Update(recipient);
            _dbContext.SaveChanges();
        }

        public void DeleteRecipient(Recipient recipient)
        {
            _dbContext.Recipients.Remove(recipient);
            _dbContext.SaveChanges();
        }
        
    }
}
