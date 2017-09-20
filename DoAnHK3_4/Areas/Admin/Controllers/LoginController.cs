using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnHK3_4.Models;
using DoAnHK3_4.Common;
using DoAnHK3_4.Security;

namespace DoAnHK3_4.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private GreetingDatabaseEntities db = new GreetingDatabaseEntities();

        // GET: Admin/Login
        [HttpGet]

        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]

        public ActionResult Login(Account account)
        {
            var pas = EncryptMD5.Encrypt(account.password);
            var result = db.Accounts.Count(a=>a.username.Equals(account.username) && a.password.Equals(pas));
            //var result = db.Accounts.Count(a => a.username.Equals(account.username) && a.password.Equals(pas));
            if (result > 0)
            {

                MySession.Username = account.username;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Account's Invalid";
                return View("Login", new Account());
            }
        }
        public ActionResult Logout()
        {
            Session.Remove("username");
            return RedirectToAction("Login", "Login");
        }
    }
}