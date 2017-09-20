using DoAnHK3_4.Models;
using DoAnHK3_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DoAnHK3_4.Common;

using Facebook;
using System.Configuration;
using BotDetect.Web.Mvc;
using System.Web.Mvc;
using DoAnHK3_4.Repository;

namespace DoAnHK3_4.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register

        RegisterAccountRepository register = new RegisterAccountRepository();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult AddAccount(Account acc)
        {

            if (ModelState.IsValid)
            {
                if (register.CountAccount(acc.username) < 1)
                {
                    acc.password = EncryptMD5.Encrypt(acc.password);

                    acc.Role = register.role();
                    register.AddAccount(acc);
                    return RedirectToAction("Index", "ContactUs");
                }
                else
                {
                    ModelState.AddModelError("", "UserName Has been used");
                }
            }
            return View("Index");
        }
    }
}