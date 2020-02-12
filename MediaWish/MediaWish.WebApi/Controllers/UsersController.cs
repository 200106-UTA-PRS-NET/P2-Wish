using System;
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

        [Route("users/info/{id}")]
        [HttpGet]//added these HttpGet 's to see documentation for swagger, needed to be on top of IaAction result
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

        [Route("users/create")]
        [HttpPost]
        public IActionResult Create([FromBody, Bind("id,name,username,password,email")]Users user)
        {
            int newid = _usersRepo.CreateUser(Mapper.Map(user));
            return CreatedAtRoute("users/info", new { id = newid });
        }
    }
}