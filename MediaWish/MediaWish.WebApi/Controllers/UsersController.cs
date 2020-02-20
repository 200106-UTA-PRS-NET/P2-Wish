using System;
using MediaWish.Library.Interfaces;
using MediaWish.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
        [HttpGet]
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
        public IActionResult Create([FromBody, Bind("name,username,password,email")]Users user)
        {
            try
            {
                _usersRepo.CreateUser(Mapper.Map(user));
                return Ok(true);
            } catch (DbUpdateException)
            {
                return Ok(false);
            } catch (ArgumentException)
            {
                return Ok(false);
            }
        }
    }
}