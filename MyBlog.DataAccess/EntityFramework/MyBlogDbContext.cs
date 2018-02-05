using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess
{
   public class MyBlogDbContext : DbContext
    {

        public DbSet<BlogUser> BlogUsers { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Liked> Likes { get; set; }

        public DbSet<Note> Notes { get; set; }

    }
}
