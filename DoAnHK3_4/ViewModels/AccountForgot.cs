using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoAnHK3_4.ViewModels
{
    public class AccountForgot
    {
        [Required(ErrorMessage = "Username Can not Empty")]
        [DisplayName("UserName:")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression("/^(([^<>()[]/.,;:s@']+(.[^<>()[]/.,;:s@']+)*)|('.+'))@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}])|(([a-zA-Z-0-9]+.)+[a-zA-Z]{2,}))$/")]
        public string username
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
        public string newPasswork
        {
            get;
            set;
        }
        public string Question
        {
            get;
            set;
        }
        [Required(ErrorMessage = "Answer Can not Empty")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "8-25 characters")]
        public string Answer
        {
            get;
            set;
        }
    }
}