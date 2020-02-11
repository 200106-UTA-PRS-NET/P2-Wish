using MediaWish.Library.Entities;
using MediaWish.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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

        public void CreateUser()
        {
            //TODO
            throw new NotImplementedException();
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
    }
}
