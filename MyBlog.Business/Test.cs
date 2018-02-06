using MyBlog.DataAccess;
using MyBlog.DataAccess.EntityFramework;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business
{
    public class Test
    {
        public Test()
        {
            //MyBlogDbContext database = new MyBlogDbContext();
            //database.BlogUsers.ToList();

            Repository<Category> catRepo = new Repository<Category>();
            List<Category> cats = catRepo.GetList();
            Repository<Note> notes = new Repository<Note>();

            Note not = new Note
            {
                Title = "baslik1",
                Content = "konu1",
                CreatedOn = DateTime.Now,
                ModifiedOn = DateTime.Now,
                ModifiedUsername = "fatiharslan",
                IsDraft = false,
                likeCount = 5,
                CategoryId = 4
            };

            notes.Insert(not);

        }
    }
}
