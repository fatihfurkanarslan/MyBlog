using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccess.EntityFramework
{
    public class BaseRepository
    {

        protected static MyBlogDbContext db;

        public BaseRepository()
        {
            CreateContext();
        }


        public static void CreateContext()
        {
            if (db == null)
            {
                db = new MyBlogDbContext();
            }
        }
    }
}
