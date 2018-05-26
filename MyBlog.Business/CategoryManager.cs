using MyBlog.Business.ResultsValidation;
using MyBlog.DataAccess.EntityFramework;
using MyBlog.Entities;
using MyBlog.Entities.UIViewModel;
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


        public BLResult<Category> AddCategory(CategoryViewModel categoryModel)
        {

            BLResult<Category> result = new BLResult<Category>();

            //TODO 
            //eper not aynı başlıkla açılırsa izin verip vermemeye karar verilsin..
            //aynı başlık kullanılmıcaksa result.error eklensin..

            //TODO 
            //Categoryid geldiği için ekranda öncelikle category seçtirmemiz lazım
            int check = categoryRepo.Insert(new Category
            {
                Title = categoryModel.Title,
                Description = categoryModel.Description

            });

            if (check > 0)
            {
                result.Entity = categoryRepo.Get(x => x.Title == categoryModel.Title);
            }

            return result;

        }

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
