using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaWish.Test.MockRepositories
{
    public class MockLibUsersRepo : IUsersRepo
    {
        static IEnumerable<Users> users = new List<Users>()
        {

            new Users()
            {
                Id = 0,
                Name = "Banana Man",
                Username = "bananaman",
                Password = "bananalover",
                Email = "bananaman12@gmail.com"
            },

            new Users()
            {
                Id = 1,
                Name = "Taong Saging",
                Username = "sagingsaba",
                Password = "sabasaging",
                Email = "sabangsaging33@gmail.com"
            }

        };


        public int CreateUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Users GetUserById(int id)
        {
            return users.Where(u => u.Id == id).Single();
        }

        public IEnumerable<Users> GetUsers()
        {
            return users.Select(u => u).ToList();
        }

        public Users Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool Register(Users u)
        {
            throw new NotImplementedException();
        }
    }
}
