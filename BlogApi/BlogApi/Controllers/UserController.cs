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

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var random = new Random();

            List<User> user = new List<User>();

            for (int i = 0; i < 5; i++)
            {
                var newModel = new User
                {
                    Id = i + 1,
                    Username = Usernames[random.Next(Usernames.Length)],
                    Email = Emails[random.Next(Emails.Length)]
                };
                user.Add(newModel);
            }

            return user;
        }

        [HttpGet("{number}")]
        public IEnumerable<User> List(int number)
        {
            var random = new Random();

            List<User> user = new List<User>();

            for (int i = 0; i < number; i++)
            {
                var newModel = new User
                {
                    Id = i + 1,
                    Username = Usernames[random.Next(Usernames.Length)],
                    Email = Emails[random.Next(Emails.Length)]
                };
                user.Add(newModel);
            }

            return user;
        }
    }
}