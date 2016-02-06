using System.Collections.Generic;
using AddressBook.DAL;

namespace AddressBook.Business.Logic.Interfaces
{
    public interface IContactTypeLogic
    {
        IEnumerable<ContactType> GetContactTypes();
        ContactType GetContactTypeById(int id);
        void AddContactType(ContactType type);
        void EditContactType(ContactType contactType);
        //ContactType GetContactTypeById(int id);
        //ContactType GetContactType();
    }
}