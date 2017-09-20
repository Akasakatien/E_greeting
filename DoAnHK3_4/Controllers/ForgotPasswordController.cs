using BotDetect.Web.Mvc;
using DoAnHK3_4.ViewModels;

using System.Linq;

using DoAnHK3_4.Models;
using System.Web.Mvc;

using DoAnHK3_4.Common;

namespace DoAnHK3_4.Controllers
{
    public class ForgotPasswordController : Controller
    {
        // GET: ForgotPassword
        GreetingDatabaseEntities greeting = new GreetingDatabaseEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult ForgotAccount(AccountForgot account)
        {
            if (!ModelState.IsValid)
            {
                var acc = greeting.Accounts.FirstOrDefault(x => x.username.Equals(account.username));
                if (acc != null)
                {
                    if (acc.question.Equals(account.Question) && acc.answer.Equals(account.Answer))
                    {
                        UserCommon user = new UserCommon();
                        user.UserName = acc.username;
                        Session.Add(CommonConstants.CHANGE_SESSION, user);
                        return RedirectToAction("Index", "ChangePassword");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Question or Answer invalid");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Don't find account");
                }

            }
            return View();


        }
    }
}