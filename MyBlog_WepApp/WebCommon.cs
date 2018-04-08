using MyBlog.Common;
using MyBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBlog_WepApp
{
    public class WebCommon : ICommon
    {
        //TODO
        //kullanıcının başlangıçta username'i defualt olarak system olabilir
        //login olduktan sonra username login olan kullanıcının username i olarak atanmalıdır.
        //su an register yaparken modifiedusername adminin username i olarak atanıyor
        public string GetUsername()
        {
            if (HttpContext.Current.Session["login"] != null)
            {
                BlogUser user = HttpContext.Current.Session["login"] as BlogUser;

                return user.Username;
            }
            return null;
        }

    }
}