using System;
using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MediaWish.WebApi.Controller
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _usersRepo;
        private readonly ILogger<UsersController> _logger;


        public UsersController(IUsersRepo usersRepo)//, Logger<UsersController> logger
        {
            _usersRepo = usersRepo;
           // _logger = logger;

        }


        [Route("users/login")]
        [HttpPost]
        public IActionResult Login([FromBody, Bind("username,password")]Users user)
        {
            var u = _usersRepo.Login(user.Username, user.Password);
            if (u != null)
            {
                Log.Information("Starting up UsersController Loggggggggggggggggg");

                // User to only show id, name, and username
                Users loggedinUser = new Users()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Username = u.Name
                };
                return Ok(loggedinUser);
            } 
            else
            {
                return Ok(null);
            }
        }


        [Route("users/info/{id}")]
        [HttpGet]//added these HttpGet 's to see documentation for swagger, needed to be on top of IaAction result
        public IActionResult Info(int id)
        {
            try
            {
                Log.Information("Starting up UsersController Loggggggggggggggg");

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
            Log.Information("Starting up UsersController Loggggggggggggg");

            int newid = _usersRepo.CreateUser(Mapper.Map(user));
            return CreatedAtRoute("users/info", new { id = newid });
        }
    }
}