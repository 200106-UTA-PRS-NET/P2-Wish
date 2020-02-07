using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Lib.Entites
{
    public partial class Users
    {
        public Users()
        {
            wishLists = new HashSet<WishList>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public virtual ICollection<WishList> wishLists { get; set; }
    }
}
