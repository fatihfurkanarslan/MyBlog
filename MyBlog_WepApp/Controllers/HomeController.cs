using MyBlog.Business;
using MyBlog.Business.ResultsValidation;
using MyBlog.Entities;
using MyBlog.Entities.UIViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog_WepApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            // Test test = new Test();


            NoteManager noteManager = new NoteManager();

            List<Note> noteList = noteManager.GetAllNotesList();

            return View(noteList);
        }

        //Indexe kategori notlarının paslamasını yapıyoruz...
        public ActionResult ByCategory(int id)
        {

            CategoryManager cm = new CategoryManager();

            Category categories = cm.CategoryById(id);

            if (categories == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {

                //sadece aynı controllerin içindeyken yönlendirme yapabiliyoruz.. !!
                return View("Index", categories.Notes);
            }


        }

        //MostPopularNotes için bir page oluşturulacak.. 
        public ActionResult MostPopularNotes()
        {
            NoteManager noteManager = new NoteManager();

            List<Note> notesPopular = noteManager.GetMostPopularNotes();
            //İndex actiona data paslama yapıyorum burada.. it means datas goes to  Index Action
            return View("Index", notesPopular);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ShowProfile()
        {
            BlogUser currentUser = null;
            currentUser = Session["login"] as BlogUser;

            UserManager usermanager = new UserManager();
            BLResult<BlogUser> result = usermanager.GetUserById(currentUser.Id);

            if (result.Errors.Count > 0)
            {

            }

            return View(result.Entity);
        }

        public ActionResult EditProfile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditProfile(BlogUser user)
        {
            return View();
        }

        public ActionResult RemoveProfile()
        {
            return View();
        }


        public ActionResult Login()
        {



            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            UserManager userManager = new UserManager();

            if (ModelState.IsValid)
            {
                BLResult<BlogUser> result = userManager.LoginUser(model);

                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }

                Session["login"] = result.Entity;
                Session.Timeout = 30;

                BlogUser user = Session["login"] as BlogUser;

       

                return RedirectToAction("Index");

            }

            return View(model);
        }


        public ActionResult LogOff()
        {

            Session.Clear();

            return RedirectToAction("Index");
        }

    
        public ActionResult Register()
        {



            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            UserManager userManager = new UserManager();

            if (ModelState.IsValid)
            {
                BLResult<BlogUser> result = userManager.RegisterUser(model);

                if (result.Errors.Count > 0)
                {
                    result.Errors.ForEach(x => ModelState.AddModelError("", x));
                    return View(model);
                }


                return RedirectToAction("RegisterApproved");

            }

            return View(model);
        }

        public ActionResult RegisterApproved()
        {
            return View();
        }

        public ActionResult UserActivate(Guid activate_guid)
        {
            UserManager user = new UserManager();
            BLResult<BlogUser> result = user.ActiivateUser(activate_guid);

            if (result.Errors.Count > 0)
            {
                TempData["errors"] = result.Errors;
                return RedirectToAction("UserActivateCancel");
            }

            return RedirectToAction("UserActivateOk");
        }

        public ActionResult UserActivateOk()
        {



            return View();
        }

        public ActionResult UserActivateCancel()
        {
            List<string> errors = new List<string>();

            if (TempData["errors"] != null)
            {
                errors = TempData["errors"] as List<string>;
            }

            return View(errors);
        }
    }

}