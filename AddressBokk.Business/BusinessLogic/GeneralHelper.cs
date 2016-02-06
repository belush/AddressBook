using AddressBook.Business.BusinessLogic;
using AddressBook.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Business
{
    public class GeneralHelper : RepositoryHelper
    {

        //TODO: убрать эту функцтю. Реализовать поиск по нормальному
        public IEnumerable<Contact> Main(string searchBy, string search, string sortBy)
        {
            //var con = GetContacts();
            IEnumerable<Contact> contacts = r.GetContacts();


            //var contacts = cons.AsQueryable();

            switch (searchBy)
            {
                case "Name":
                    contacts = contacts.Where(c => c.ContactName.ToLower().StartsWith(search.ToLower()) || search == null);
                    break;
                case "Surname":
                    contacts = contacts.Where(c => c.ContactSurname.ToLower().StartsWith(search.ToLower()) || search == null);
                    break;
                case "PhoneNumber":
                    contacts = contacts.Where(c => c.ContactPhoneNumber.ToString().StartsWith(search) || search == null);
                    break;
                case "Email":
                    contacts = contacts.Where(c => c.ContactEmail.ToLower().StartsWith(search.ToLower()) || search == null);
                    break;
                default:
                    break;
            }

            switch (sortBy)
            {
                case "Name desc":
                    contacts = contacts.OrderByDescending(c => c.ContactName);
                    break;
                case "Name":
                    contacts = contacts.OrderBy(c => c.ContactName);
                    break;
                case "Surname desc":
                    contacts = contacts.OrderByDescending(c => c.ContactSurname);
                    break;
                case "Surname":
                    contacts = contacts.OrderBy(c => c.ContactSurname);
                    break;
                case "PhoneNumber desc":
                    contacts = contacts.OrderByDescending(c => c.ContactPhoneNumber);
                    break;
                case "PhoneNumber":
                    contacts = contacts.OrderBy(c => c.ContactPhoneNumber);
                    break;
                case "Email desc":
                    contacts = contacts.OrderByDescending(c => c.ContactPhoneNumber);
                    break;
                case "Email":
                    contacts = contacts.OrderBy(c => c.ContactPhoneNumber);
                    break;
                default:
                    contacts = contacts.OrderBy(c => c.ContactName);
                    break;
            }

            return contacts;
        }

        public IQueryable<Contact> Search(string searchBy, string search, IQueryable<Contact> contacts)
        {
            switch (searchBy)
            {
                case "Name":
                    contacts = contacts.Where(c => c.ContactName.StartsWith(search) || search == null);
                    break;
                case "Surname":
                    contacts = contacts.Where(c => c.ContactSurname.StartsWith(search) || search == null);
                    break;
                case "PhoneNumber":
                    contacts = contacts.Where(c => c.ContactPhoneNumber.ToString().StartsWith(search) || search == null);
                    break;
                case "Email":
                    contacts = contacts.Where(c => c.ContactEmail.StartsWith(search) || search == null);
                    break;
                default:
                    break;
            }
            return contacts;
        }

        public IQueryable<Contact> Sort(string sortBy, IQueryable<Contact> contacts)
        {
            //var contacts = GetContacts().AsQueryable();

            switch (sortBy)
            {
                case "Name desc":
                    contacts = contacts.OrderByDescending(c => c.ContactName);
                    break;
                case "Name":
                    contacts = contacts.OrderBy(c => c.ContactName);
                    break;
                case "Surname desc":
                    contacts = contacts.OrderByDescending(c => c.ContactSurname);
                    break;
                case "Surname":
                    contacts = contacts.OrderBy(c => c.ContactSurname);
                    break;
                case "PhoneNumber desc":
                    contacts = contacts.OrderByDescending(c => c.ContactPhoneNumber);
                    break;
                case "PhoneNumber":
                    contacts = contacts.OrderBy(c => c.ContactPhoneNumber);
                    break;
                case "Email desc":
                    contacts = contacts.OrderByDescending(c => c.ContactPhoneNumber);
                    break;
                case "Email":
                    contacts = contacts.OrderBy(c => c.ContactPhoneNumber);
                    break;
                default:
                    contacts = contacts.OrderBy(c => c.ContactName);
                    break;
            }

            return contacts;
        }
    }
}
