using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnHK3_4.ViewModels
{
    public class ChangeAccountForgot
    {
        [Required(ErrorMessage = "Password Can not Empty")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "8-25 characters")]
        [DataType(DataType.Password)]
        public string confirmPasswork
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Password Can not Empty")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "8-25 characters")]
        [DataType(DataType.Password)]
        public string newPasswork
        {
            get;
            set;
        }
    }
}