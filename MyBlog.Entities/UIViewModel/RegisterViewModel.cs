using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.Entities.UIViewModel
{
    public class RegisterViewModel
    {
        [DisplayName("User Name"), Required(ErrorMessage = "Bu alan boş geçilemez"), StringLength(50, ErrorMessage ="This field is just able to be for 50 chars.")]
        public string Username { get; set; }

        [DisplayName("Email"), Required(ErrorMessage = "Bu alan boş geçilemez"), StringLength(100, ErrorMessage = "This field is just able to be for 50 chars.")]
        public string Email { get; set; }

        [DisplayName("Password"), Required(ErrorMessage = "Bu alan boş geçilemez"), StringLength(50, ErrorMessage = "This field is just able to be for 50 chars.")]
        public string Password { get; set; }

        [DisplayName("Repassword"), Required(ErrorMessage = "Bu alan boş geçilemez"), StringLength(50, ErrorMessage = "This field is just able to be for 50 chars.")]
        public string Repassword { get; set; }


    }
}