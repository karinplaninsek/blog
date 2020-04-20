using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }

    public class User
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool isRegistered { get; set; }
        public string? Address { get; set; }

        public ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public string PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Media> Media { get; set; }
    }
    
    public class Media
    {
        public string MediaId { get; set; }
        public string MediaType { get; set; }
        public string Title { get; set; }
        public string PostId { get; set; }
        public Post Post { get; set; }
    }

    public class Category
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
