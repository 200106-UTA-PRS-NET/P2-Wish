using System;
using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaWish.WebApi.Controller
{
    [ApiController]
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
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

        [HttpPost]
        [Route("users/create")]
        public IActionResult Create([FromBody, Bind("id,name,username,password,email")]Users user)
        {
            int newid = _usersRepo.CreateUser(Mapper.Map(user));
            return CreatedAtRoute("users/info", new { id = newid });
        }
    }
}