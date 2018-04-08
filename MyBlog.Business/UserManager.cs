﻿using MyBlog.Business.ResultsValidation;
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
                }
            }


            return result;

        }

        

    }
}
