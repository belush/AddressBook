using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.DAL;

namespace AddressBook.Business.Logic.Interfaces
{
    public interface IUserLogic
    {
        void ConfirmRegistration(string userLogin, string confirmString);
        void EditUser(User user);
        User GetUserById(int id);
        User GetUserByLogin(string login);
    }
}
