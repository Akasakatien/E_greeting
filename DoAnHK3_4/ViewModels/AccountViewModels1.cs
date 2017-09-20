using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnHK3_4.ViewModels
{
    public class AccountViewModels1
    {
        [Required(ErrorMessage = "Username Can not Empty")]
        [DisplayName("UserName")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        public string username { get; set; }
        [Required(ErrorMessage = "Password Can not Empty")]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "8-30 characters")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string password { get; set; }
    }
}