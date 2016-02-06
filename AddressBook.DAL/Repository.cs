using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DAL
{
    public class Repository
    {
        private readonly AddressBookContext db = new AddressBookContext();

        //ContactType
        public ContactType GetContactType()
        {
            ContactType contactType = db.ContactTypes.FirstOrDefault();
            return contactType;
        }

        public ContactType GetContactTypeById(int id)
        {
            ContactType contactType = db.ContactTypes.FirstOrDefault(c => c.ContactTypeId == id);
            return contactType;
        }

        public List<ContactType> GetContactTypes()
        {
            return db.ContactTypes.ToList();
        }

        public void AddContactType(ContactType type)
        {
            ContactType contactType = db.ContactTypes.FirstOrDefault(c => c.ContactTypeName == type.ContactTypeName);
            if (contactType == null)
            {
                db.ContactTypes.Add(type);
                db.SaveChanges();
            }
        }

        //Contact
        public Contact GetContactById(int id)
        {
            Contact contact = db.Contacts.FirstOrDefault(c => c.ContactId == id);
            return contact;
        }

        public void Edit(Contact contact)
        {
            db.Entry(contact).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteContact(int id)
        {
            Contact contact = GetContactById(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
        }

        public List<Contact> GetContacts()
        {
            return db.Contacts.ToList();
        }

        public void AddDefaultContact(Contact newContact)
        {
            Contact contact = db.Contacts.FirstOrDefault(c => c.ContactName == newContact.ContactName &&
                c.ContactSurname == newContact.ContactSurname &&
                c.ContactMidName == newContact.ContactMidName);
            if (contact == null)
            {
                db.Contacts.Add(newContact);
                db.SaveChanges();
            }
        }

        public void AddContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }


        //User
        public User GetUser(int id)
        {
          //  List<User> us = db.Users.ToList();
            User user = db.Users.FirstOrDefault(u => u.UserId == id);
            return user;
        }

        public List<User> GetUsers()
        {
            List<User> users = db.Users.ToList();
            return users;
        }

        public User GetUserByLogin(string login)
        {
            //List<User> us = db.Users.ToList();
            User user = db.Users.FirstOrDefault(u => u.UserLogin == login);
            return user;
        }

        public void EditUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
