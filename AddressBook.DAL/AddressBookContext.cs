using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AddressBook.DAL
{
    public class AddressBookContext : DbContext
    {
        public AddressBookContext() : base("AddressBookConnection")
        { }

        public DbSet<Contact> Contacts { set; get; }
        public DbSet<ContactType> ContactTypes { set; get; }
        public DbSet<User> Users { set; get; }
    }
}
