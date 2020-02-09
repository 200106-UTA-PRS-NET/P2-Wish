using System;
using System.Collections.Generic;
using System.Text;

namespace MovieBox.Library.Interfaces
{
    public interface IUsersRepo
    {
        public IEnumerable<Users> GetUsers();
        public Users GetUserByID(int id);
        public bool AddUser(Users user);
        public bool RemoveUser(int id);
    }
}
