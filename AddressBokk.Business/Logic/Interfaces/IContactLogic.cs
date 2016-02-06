using System.Collections.Generic;
using AddressBook.DAL;

namespace AddressBook.Business.Logic.Interfaces
{
    public interface IContactLogic
    {
        IEnumerable<Contact> GetContacts();
        void AddContact(Contact contact);
        void EditContact(Contact contact);
        void DeleteContact(int id);
        Contact GetContactById(int id);
    }
}