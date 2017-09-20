using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoAnHK3_4.ViewModels
{
    public class AccountChange
    {
        [Required(ErrorMessage = "Password Can not Empty")]
        [StringLength(25, MinimumLength = 8, ErrorMessage = "8-25 characters")]
        [DataType(DataType.Password)]
        public string newPasswork
        {
            get;
            set;
        }
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
        public string oldPasswork
        {
            get;
            set;
        }
    }
}