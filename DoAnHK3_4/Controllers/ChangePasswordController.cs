using DoAnHK3_4.Common;
using DoAnHK3_4.ViewModels;
using DoAnHK3_4.Models;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BotDetect.Web.Mvc;
using DoAnHK3_4.Repository;

namespace DoAnHK3_4.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePassword
        ChangePasswordRepository change = new ChangePasswordRepository();

        public ActionResult Index()
        {

            var session = (UserCommon)Session[CommonConstants.CHANGE_SESSION];

            if (session == null)
            {
                return RedirectToAction("Index", "ContactUs");
            }
            return View();
        }
        //forgot
        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult ChangeAccount(ChangeAccountForgot account)
        {
            var session = (UserCommon)Session[Common.CommonConstants.CHANGE_SESSION];

            var user = change.findAccount(session.UserName);

            if (ModelState.IsValid)
            {
                
                      if (account.newPasswork.Equals(account.confirmPasswork))
                        {

                            user.password = EncryptMD5.Encrypt(account.newPasswork);
                            change.AddChange(user);
                            return Redirect("/");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Passswork do not match ");

                        }
                
            }

            return View("Index");

        }
    }
}