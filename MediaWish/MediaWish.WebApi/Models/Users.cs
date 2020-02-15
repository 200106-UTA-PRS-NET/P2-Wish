using System.ComponentModel.DataAnnotations;

namespace MediaWish.WebApi.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(50, MinimumLength = 7, ErrorMessage = "Username must be at least 7 characters.")]
        public string Username { get; set; }
        [StringLength(200, MinimumLength = 7, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
