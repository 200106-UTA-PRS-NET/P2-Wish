using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MovieBox.Library.Interfaces;
using MovieBox.WebAPI.Models;

namespace MovieBox.WebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersRepo _usersRepo;

        public UsersController(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }

        [HttpGet]
        public IEnumerable<Users> Index()
        {
            var users = Mapper.Map(_usersRepo.GetUsers());
            return users;
        }



    }
}