using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BlogApi.Models;

namespace BlogApi
{
    public class Program
    {
        /*public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });*/

        public static void Main()
        {
            using (var db = new BlogContext())
            {
                // Create
                Console.WriteLine("Creating new user");
                db.Add(new User { UserId = "8", Username = "karinplaninsek", Email = "karin.planinsek@gmail.com", isRegistered = true });
                db.SaveChanges();

                // Read
                Console.WriteLine("Searching for users");
                var user = db.Users
                    .OrderBy(u => u.UserId)
                    .First();

                // Update
                Console.WriteLine("Updating blog and adding a post");
                user.UserId = "8";
                user.Posts.Add(
                    new Post
                    {
                        UserId = "8",
                        PostId = "1",
                        Title = "Initial Post",
                        Content = "Test"
                    });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete post");
                db.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
