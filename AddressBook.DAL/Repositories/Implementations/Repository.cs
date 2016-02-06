using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DAL.Repositories.Implementations
{
    public class Repository
    {
        protected readonly AddressBookContext db = new AddressBookContext();

        public Repository(AddressBookContext context)
        {
            db = context;
        }
    }
}
