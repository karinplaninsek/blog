using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogApi.Models;

namespace BlogApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static readonly string[] Usernames = new[]
        {
            "jananovak", "marko.polo", "zupanjan", "gregorcmeta", "katarinah"
        };

        private static readonly string[] Emails = new[]
        {
            "jana.novak@gmail.com", "marko.polo@gmail.com", "jan.zupan@gmail.com", "katarina.hrast@gmail.com"
        };

        /*User users = new User
        {
            Id = "",
            Username = "jananovak",
            Email = "jana.novak@gmail.com",
            isRegistered = true
        };*/

        List<User> users = new List<User>
        {
            new User{ UserId = "1", Username = "jana.novak", Email = "jana.novak@gmail.com", isRegistered = true },
            new User{ UserId = "2", Username = "marko.polo", Email ="marko.polo@gmail.com", isRegistered = false, Address = "Slovenska ulica 5, Ljubljana" },
            new User{ UserId = "3", Username = "zupanjan", Email = "jan.zupan@gmail.com", isRegistered = true, Address = "Tomšičeva cesta 8, Kamnik" },
            new User{ UserId = "4", Username = "gregorcmeta", Email = "meta.gregorc@gmail.com", isRegistered = true },
            new User{ UserId = "5", Username = "katarinah", Email = "katarina.hrastnik@gmail.com", isRegistered = false }
        };

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return this.users;
        }

        [HttpGet("{number}")]
        public IEnumerable<User> List(int number)
        {
            var random = new Random();

            List<User> user = new List<User>();

            for (int i = 0; i < number; i++)
            {
                var id = i + 1;
                var newModel = new User
                {
                    UserId = id.ToString(),
                    Username = Usernames[random.Next(Usernames.Length)],
                    Email = Emails[random.Next(Emails.Length)],
                };
                user.Add(newModel);
            }

            return user;
        }
    }
}