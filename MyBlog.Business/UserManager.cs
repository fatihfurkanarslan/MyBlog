using MyBlog.Business.ResultsValidation;
using MyBlog.Common;
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
    public class UserManager
    {

        Repository<BlogUser> userRepo = new Repository<BlogUser>();

        public List<BlogUser> GetAllUserList()
        {



            return userRepo.GetList();
        }


       public BLResult<BlogUser> LoginUser(LoginViewModel model)
        {
            BLResult<BlogUser> result = new BLResult<BlogUser>();

            result.Entity = userRepo.Get(x => x.Username == model.Username && x.Password == model.Password);

            if (result.Entity != null)
            {
                if (!result.Entity.IsActive)
                {
                    result.Errors.Add("User is not active. Please check your emails for activation..");
                }
            }
            else{
                result.Errors.Add("Invalid email or password. Please try again.");
            }

            return result;
        }

        public BLResult<BlogUser> RegisterUser(RegisterViewModel user)
        {
            BLResult<BlogUser> result = new BLResult<BlogUser>();

            BlogUser userToInsert = userRepo.Get(x => x.Username == user.Username || x.Email == user.Email);

            if (userToInsert != null)
            {
                if(userToInsert.Username == user.Username)
                {
                    result.Errors.Add("Username is not available.");
                }
                if(userToInsert.Email == user.Email)
                {
                    result.Errors.Add("Email is not available.");
                }
            }
            else
            {
                int check = userRepo.Insert(new BlogUser {
                    Username = user.Username,
                    Email = user.Email,
                    Password = user.Password,
                    ActivateGuid = Guid.NewGuid(),
                    Name = "name",
                    Surname = "surname",
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now,
                    ModifiedUsername = AppHelper.Common.GetUsername(),
                    IsActive = false,
                    IsAdmin = false
                });

                if (check > 0)
                {
                    result.Entity = userRepo.Get(x => x.Username == user.Username);

                    
                    string siteUri = ConfigHelper.Get<string>("SiteRootUri");
                    string activeUri = $"{siteUri}/Home/UserActivate/{result.Entity.ActivateGuid}";
                    string body = $"Merhaba {result.Entity.Username} {result.Entity.Surname} <br><br> Hesabınızı" +
                        $"aktifleştirmek için <a href='{activeUri}' target='_blank'>tıklayınız</a>.";

                    MailHelper.SendMail(body, result.Entity.Email, "Hesap Aktifleştirme");

                }
            }

            return result;

        }

        public BLResult<BlogUser> GetUserById(int id)
        {
            BLResult<BlogUser> result = new BLResult<BlogUser>();
            result.Entity = userRepo.Get(x => x.Id == id);

            if (result.Entity == null)
            {
                result.Errors.Add("Kullanıcı Bulunamadı.");
            }


            return result;
        }

        public BLResult<BlogUser> ActiivateUser(Guid activateId)
        {
            BLResult<BlogUser> result = new BLResult<BlogUser>();

            result.Entity = userRepo.Get(x => x.ActivateGuid == activateId);

            if (result.Entity != null)
            {
                if (result.Entity.IsActive)
                {
                    //hatalara active edilmiş kullanıcı hatası eklenecek..
                    result.Errors.Add("The user is already activeted.");
                    return result;
                }

                result.Entity.IsActive = true;
                userRepo.Update(result.Entity);

            }
            else
            {
                result.Errors.Add("No active users found.");
            }

            
            return result;
        }

    }
}
