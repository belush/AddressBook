using System.Collections.Generic;
using AddressBook.Business.Logic.Interfaces;
using AddressBook.DAL;
using AddressBook.DAL.Repositories.Interfaces;

namespace AddressBook.Business.Logic.Implementations
{
    public class ContactLogic : IContactLogic
    {
        private readonly IContactRepository _repository;

        public ContactLogic(IContactRepository repository)
        {
            _repository = repository;
        }

        public void AddContact(Contact contact)
        {
            _repository.AddContact(contact);
        }

        public void DeleteContact(int id)
        {
            _repository.DeleteContact(id);
        }

        public void EditContact(Contact contact)
        {
            _repository.Edit(contact);
        }

        public Contact GetContactById(int id)
        {
            return _repository.GetContactById(id);
        }

        public IEnumerable<Contact> GetContacts()
        {
            return _repository.GetContacts();
        }
    }
}