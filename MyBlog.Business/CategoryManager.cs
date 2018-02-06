using MyBlog.DataAccess.EntityFramework;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business
{
    public class CategoryManager
    {

        private Repository<Category> cat = new Repository<Category>();

        public List<Category> GetCategories()
        {

            return cat.GetList();

        }

    }
}
