using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressBook.Business.Logic.Interfaces;
using AddressBook.DAL;
using AddressBook.DAL.Repositories.Interfaces;

namespace AddressBook.Business.Logic.Implementations
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRepository _repository;


        public UserLogic(IUserRepository repository)
        {
            _repository = repository;
        }

        public void ConfirmRegistration(string userLogin, string confirmString)
        {
            throw new NotImplementedException();
        }

        public void EditUser(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }
    }
}
