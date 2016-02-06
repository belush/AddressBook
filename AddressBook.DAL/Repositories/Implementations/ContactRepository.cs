using AddressBook.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DAL.Repositories.Implementations
{
    public class ContactRepository : Repository, IContactRepository
    {
        public ContactRepository(AddressBookContext context) : base(context)
        { }

        public void AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            //todo: переписать функцию. чтобы она принимала "Contact contact"
            Contact contact = GetContactById(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }

        public void Edit(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Contact GetContactById(int id)
        {
            return db.Contacts.FirstOrDefault(c => c.ContactId == id);
        }

        public List<Contact> GetContacts()
        {
            return db.Contacts.ToList();
        }
    }
}
