using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetUserById(int id);
        List<User> GetUsers();
        User GetUserByLogin(string login);
        void EditUser(User user);
    }
}
