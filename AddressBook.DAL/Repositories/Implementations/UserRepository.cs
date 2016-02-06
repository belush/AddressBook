using AddressBook.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.DAL.Repositories.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(AddressBookContext context) : base(context)
        { }

        public void EditUser(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }

        public List<User> GetUsers()
        {
            return db.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(u => u.UserId == id);          
        }

        //TODO: узнать нужна ли эта функция
        public User GetUserByLogin(string login)
        {
            return db.Users.FirstOrDefault(u => u.UserLogin == login);
        }
    }
}
