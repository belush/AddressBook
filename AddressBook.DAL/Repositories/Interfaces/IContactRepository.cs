using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DAL.Repositories.Interfaces
{
    public interface IContactRepository
    {
        List<Contact> GetContacts();
        void AddContact(Contact contact);
        void DeleteContact(int id);
        void Edit(Contact contact);
        Contact GetContactById(int id);
    }
}
