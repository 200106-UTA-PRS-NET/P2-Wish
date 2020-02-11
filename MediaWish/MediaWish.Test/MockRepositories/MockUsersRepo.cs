using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaWish.Test.MockRepositories
{
    public class MockUsersRepo : IUsersRepo
    {

        public int CreateUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
