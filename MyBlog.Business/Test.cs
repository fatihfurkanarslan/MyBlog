using MyBlog.DataAccess;
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
            MyBlogDbContext database = new MyBlogDbContext();
            database.Database.CreateIfNotExists();
        }
    }
}
