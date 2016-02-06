using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Business.Logic.Interfaces;
using AddressBook.DAL;
using AddressBook.DAL.Repositories.Interfaces;

namespace AddressBook.Business.Logic.Implementations
{
    public class ContactTypeLogic :  IContactTypeLogic
    {
        private readonly IContactTypeRepository _repository;

        public ContactTypeLogic(IContactTypeRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ContactType> GetContactTypes()
        {
            return _repository.GetContactTypes();
        }

        public ContactType GetContactTypeById(int id)
        {
            return _repository.GetContactTypeById(id);
        }

        public void AddContactType(ContactType type)
        {
            _repository.AddContactType(type);
        }

        public void EditContactType(ContactType contactType)
        {
            _repository.Edit(contactType);
        }
    }
}
