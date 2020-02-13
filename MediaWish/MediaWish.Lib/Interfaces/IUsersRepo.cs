using MediaWish.Library.Entities;
using System.Collections.Generic;

namespace MediaWish.Library.Interfaces
{
    public interface IUsersRepo
    {
        public Users GetUserById(int id); // get current logged in user
        public IEnumerable<Users> GetUsers(); // returns a list of all users registered in user db
        public int CreateUser(Users user); // create user and return newuser id
        public Users Login(string username, string password);
        public bool Register(Users u);
    }
}
