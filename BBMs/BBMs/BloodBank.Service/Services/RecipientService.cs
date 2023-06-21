using BloodBank.Domain.Interfaces;
using BloodBank.Domain.Models;
using BloodBank.Service.DTOs;

namespace BloodBank.Service.Services
{
    public class RecipientService : IRecipientService
    {

        private readonly IRecipientRepository _recipientRepository;

        public RecipientService(IRecipientRepository recipientRepository)
        {
            _recipientRepository = recipientRepository;

        }

        public Recipient GetRecipientById(int id)
        {
            return _recipientRepository.GetRecipientById(id);
        }


        public ICollection<Recipient> GetAllRecipients()
        {
            return _recipientRepository.GetAllRecipients();
        }

        public bool AddRecipient(RecipientDto recipient)
        {
            var temp = new Recipient
            {
                RecipientName = recipient.RecipientName,
                Age = recipient.Age,
                BloodGroup = recipient.BloodGroup,
                ContactNumber = recipient.ContactNumber,
                Gender = recipient.Gender,
                BloodBankId = recipient.BloodBankId,
            };
           var s = _recipientRepository.AddRecipient(temp);
            if(s)
            {
              return true;
            }
            return false;
           
        }

        public void DeleteRecipient(Recipient recipient) 
        {
          _recipientRepository.DeleteRecipient(recipient);
        }
        public void UpdateRecipient(Recipient recipient)
        {
            _recipientRepository.UpdateRecipient(recipient);    
        }
    }
}

