using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaWish.WebApi.Controller
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _usersRepo;

        public UsersController(IUsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }

        [HttpGet]
        [Route("users/info/{id}")]
        public IActionResult Info(int id)
        {
            try
            {
                var user = Mapper.Map(_usersRepo.GetUserById(id));
                return Ok(user);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

        }
    }
}