using System.Collections.Generic;

namespace AddressBook.DAL.Repositories.Interfaces
{
    public interface IContactTypeRepository
    {
        ContactType GetContactType();
        ContactType GetContactTypeById(int id);
        List<ContactType> GetContactTypes();
        void AddContactType(ContactType type);
        void Edit(ContactType contactType);
    }
}