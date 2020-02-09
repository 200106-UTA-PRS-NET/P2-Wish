using Microsoft.EntityFrameworkCore;
using MovieBox.Library;
using MovieBox.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieBox.DataAccess.Repositories
{
    public class UsersRepo : IUsersRepo
    {
        MovieBoxContext _db;

        public UsersRepo(MovieBoxContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool AddUser(Users user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        public Users GetUserByID(int id)
        {
            var user = _db.Users.Where(u => u.Id == id).Single();
            return user;
        }

        public IEnumerable<Users> GetUsers()
        {
            var users = _db.Users.Select(u => u).ToList();
            return users;
        }

        public bool RemoveUser(int id)
        {
            try
            {
                var user = _db.Users.Where(u => u.Id == id).Single();
                _db.Users.Remove(user);
                _db.SaveChanges();
                return true;
            } 
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (DbUpdateException)
            {
                return false;
            }

        }
    }
}
