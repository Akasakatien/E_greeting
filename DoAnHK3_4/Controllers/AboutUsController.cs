using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnHK3_4.Models;
using DoAnHK3_4.ViewModels;

namespace DoAnHK3_4.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        public ActionResult Index()
        {
            AccountViewModels acc = new AccountViewModels();
            acc.accountView = new Account();
            return View("Index", acc);
        }
    }
}