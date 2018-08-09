using MyBlog.Business;
using MyBlog.Entities;
using MyBlog.Entities.UIViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog_WepApp.Controllers
{
    public class ManagerPanelController : Controller
    {
        NoteManager noteManager = new NoteManager();
        CategoryManager catManager = new CategoryManager();
        // GET: ManagerPanel
        public ActionResult AddNote()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddNote(NoteViewModel model)
        {

            noteManager.AddNote(model);

            return View();
        }

        public ActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryViewModel model)
        {
      
            catManager.AddCategory(model);

            return View();
        }

        public ActionResult ListCategories()
        {
            List<Category> list = CacheHelper.GetFromCategoriesCache();

            return View();
        }


    }
}