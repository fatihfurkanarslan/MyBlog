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

        Repository<Category> categoryRepo = new Repository<Category>();

        public List<Category> CategoryList()
        {

            return categoryRepo.GetList();

        }

        public Category CategoryById(int id)
        {
            return categoryRepo.Get(x => x.Id == id);
        }

    }
}
