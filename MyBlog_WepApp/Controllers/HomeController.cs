using MyBlog.Business;
using MyBlog.Business.ResultsValidation;
using MyBlog.Entities;
using MyBlog.Entities.UIViewModel;
using MyBlog_WepApp.ViewModels;
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

                //sadece aynı controllerlarin içindeyken yönlendirme yapabiliyoruz.. !!
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

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "Invalid Profile Update Operation",
                };
                errorModel.Items = result.Errors;

                return View("Error", errorModel);
            }

            return View(result.Entity);
        }

        public ActionResult EditProfile()
        {
            BlogUser currentUser = null;
            currentUser = Session["login"] as BlogUser;

            UserManager usermanager = new UserManager();
            BLResult<BlogUser> result = usermanager.GetUserById(currentUser.Id);

            if (result.Errors.Count > 0)
            {

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "Invalid Profile Update Operation",
                };
                errorModel.Items = result.Errors;

                return View("Error", errorModel);
            }

            return View(result.Entity);
        }

        [HttpPost]
        public ActionResult EditProfile(BlogUser user, HttpPostedFileBase ProfileImage)
        {
            if (ProfileImage != null
                && (ProfileImage.ContentType == "image/jpeg"
                || ProfileImage.ContentType == "image/jpg"
                || ProfileImage.ContentType == "image/jpeg"))
            {
                string filename = $"user_{user.Id}.{ProfileImage.ContentType.Split('/')[1]}";

                ProfileImage.SaveAs(Server.MapPath($"~/images/{filename}"));
                user.UserImageFileName = filename;
            }

            UserManager usermanager = new UserManager();
            BLResult<BlogUser> result = usermanager.UpdateProfile(user);

            if (result.Errors.Count > 0)
            {

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "Profil Güncelleme Başarısız",
                    RedirectingUrl = "/Home/EditProfile"
                };
                errorModel.Items = result.Errors;

                return View("Error", errorModel);
            }

            //kullanıcı güncellendiği için sessionda güncellendi..
            Session["login"] = result.Entity;

            return RedirectToAction("ShowProfile");


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

                OkViewModel okModel = new OkViewModel() {
                    Title = "Registration Okay",
                    Header = "Please check your email box to activate your account."
                };

                return View("Ok", okModel);

            }

            return View(model);
        }

        public ActionResult UserActivate(Guid activate_guid)
        {
            UserManager user = new UserManager();
            BLResult<BlogUser> result = user.ActiivateUser(activate_guid);

            if (result.Errors.Count > 0)
            {

                ErrorViewModel errorModel = new ErrorViewModel()
                {
                    Title = "Invalid Registration",                    
                };
                errorModel.Items = result.Errors;

                return View("Error", errorModel);
            }

            OkViewModel okModel = new OkViewModel() {
                Title = "Registration Susccessfull.",
                RedirectingUrl = "/Home/Login"
            };

            okModel.Items.Add("Please activate your account via activate mail. Check your e-mail box.");

            return View("Ok", okModel);
        }

        public ActionResult CommentList(int id)
        {
            //id bossa/(id boş gelebilir mi???) ? güvenlik önlemi nullable yapılabilir..

            NoteManager noteManager = new NoteManager();
            Note note = noteManager.GetNotebyId(id);
            
            return PartialView("_PartialComments", note.Comment);
        }

        //bu method yerine artık generic error sayfası kullanılacak
        //public ActionResult UserActivateCancel()
        //{
        //    List<string> errors = new List<string>();

        //    if (TempData["errors"] != null)
        //    {
        //        errors = TempData["errors"] as List<string>;
        //    }

        //    return View(errors);
        //}
    }

}