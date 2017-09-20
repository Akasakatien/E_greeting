using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnHK3_4.ViewModels
{
    public class InfoAccountViewModel
    {
        [Required(ErrorMessage = "Answer Can not Empty")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "8-25 characters")]
        public string answer { get; set; }
        [Required(ErrorMessage = "lastname Can not Empty")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "8-25 characters")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "lastname Can not Special characters")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "firstname Can not Empty")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "8-25 characters")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "firstname Can not Special characters")]
        public string lastName { get; set; }
        public string gender { get; set; }
        [Required(ErrorMessage = "Adress Can not Empty")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Address invailid")]
        public string address { get; set; }
        public string country { get; set; }
        [Required(ErrorMessage = "Phone Can not Empty")]
        [StringLength(12, MinimumLength = 10, ErrorMessage = "Phone invailid")]
        [RegularExpression(@"^\+?\d{1,3}?[- .]?\(?(?:\d{2,3})\)?[- .]?\d\d\d[- .]?\d\d\d\d$", ErrorMessage = "Phone Can not Special characters")]
        public string mobile { get; set; }
    }
}