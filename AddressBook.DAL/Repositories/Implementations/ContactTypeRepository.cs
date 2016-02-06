using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AddressBook.DAL.Repositories.Interfaces;

namespace AddressBook.DAL.Repositories.Implementations
{
    public class ContactTypeRepository : Repository, IContactTypeRepository
    {
        public ContactTypeRepository(AddressBookContext context) : base(context)
        {
        }

        public void AddContactType(ContactType type)
        {
            db.ContactTypes.Add(type);
            db.SaveChanges();
        }

        public void Edit(ContactType contactType)
        {
            db.Entry(contactType).State = EntityState.Modified;
            db.SaveChanges();
        }

        /// TODO: сделать рефакторинг. убрать эту функцию
        public ContactType GetContactType()
        {
            return db.ContactTypes.FirstOrDefault();
        }

        public ContactType GetContactTypeById(int id)
        {
            return db.ContactTypes.FirstOrDefault(c => c.ContactTypeId == id);
        }

        public List<ContactType> GetContactTypes()
        {
            return db.ContactTypes.ToList();
        }
    }
}
