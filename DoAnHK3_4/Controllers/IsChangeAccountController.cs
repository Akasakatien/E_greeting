using BotDetect.Web.Mvc;
using DoAnHK3_4.Common;
using DoAnHK3_4.Models;
using DoAnHK3_4.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnHK3_4.Controllers
{
    public class IsChangeAccountController : Controller
    {
        // GET: IsChangeAccount
        // GET: IsChangeAccount
        GreetingDatabaseEntities greeting = new GreetingDatabaseEntities();
        public ActionResult Index()
        {
            var session = (UserCommon)Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                return RedirectToAction("Index", "ContactUs");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult IsChangePassword(AccountChange account)
        {
            if (ModelState.IsValid)
            {
                var session = (UserCommon)Session[CommonConstants.USER_SESSION];
                var acc = greeting.Accounts.FirstOrDefault(x => x.username.Equals(session.UserName));
                if (!account.oldPasswork.Equals(account.newPasswork))
                {
                    if (account.newPasswork.Equals(account.confirmPasswork))
                    {
                        acc.password = EncryptMD5.Encrypt(account.newPasswork);

                        greeting.Accounts.Attach(acc);
                        greeting.Entry(acc).State = System.Data.Entity.EntityState.Modified;
                        greeting.Configuration.ValidateOnSaveEnabled = false;
                        greeting.SaveChanges();
                        return RedirectToAction("Index", "ContactUs");
                    }
                    else
                    {
                        ModelState.AddModelError("", "account don't like that");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "account don't like that");
                }

            }
            return View("Index");
        }
    }
}