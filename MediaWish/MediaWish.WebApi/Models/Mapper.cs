using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWish.WebApi.Models
{
    public class Mapper
    {
        #region Users
        public static Users Map(Library.Entities.Users users)
        {
            return new Users()
            {
                Id = users.Id,
                Name = users.Name,
                Username = users.Username,
                Email = users.Email,
                Password = users.Password,
            };
        }
        public static Library.Entities.Users Map(Users users)
        {
            return new Library.Entities.Users()
            {
                Id = users.Id,
                Name = users.Name,
                Username = users.Username,
                Email = users.Email,
                Password = users.Password,
            };
        }
        #endregion
    }
}
