using DoAnHK3_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DoAnHK3_4.ViewModels
{
    public class SendingViewModel
    {
        [Required(ErrorMessage = "You must enter a sender name")]
        public string senderName { get; set; }
        [Required(ErrorMessage = "You must enter a recipient name")]
        public string rersiveName { get; set; }
        [Required(ErrorMessage = "You must enter email of recipient")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string addressTo { get; set; }
        [Required(ErrorMessage = "You must enter custom message")]
        public string customMessenger { get; set; }
    }
}