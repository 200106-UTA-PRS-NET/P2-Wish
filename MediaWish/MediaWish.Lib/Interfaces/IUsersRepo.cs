using MediaWish.Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWish.Library.Interfaces
{
    public interface IUsersRepo
    {
        public void CreateUser(); // create user account
        public Users GetUserById(int id); // get current logged in user
        public IEnumerable<Users> GetUsers(); // returns a list of all users registered in user db
    }
}
