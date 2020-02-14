using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MediaWish.DataAccess.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        readonly MediaWishContext _db;

        public UsersRepo(MediaWishContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public int CreateUser(Users user)
        {
            _db.Add(user);
            _db.SaveChanges();
            return user.Id;
        }

        public Users GetUserById(int id)
        {
            var user = _db.users.Where(u => u.Id == id).Single();
            return user;
        }

        public IEnumerable<Users> GetUsers()
        {
            var users = _db.users.Select(u => u).ToList();
            return users;
        }

        public Users Login(string username, string password)
        {
            try
            {
                var user = _db.users.Where(u => u.Username == username && u.Password == password).Single();
                return user;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }
    }
}
