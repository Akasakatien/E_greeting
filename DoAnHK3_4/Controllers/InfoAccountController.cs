using System.Linq;
using System.Web.Mvc;
using System.Data;
using DoAnHK3_4.Models;
using DoAnHK3_4.Common;
using BotDetect.Web.Mvc;
using DoAnHK3_4.Repository;

namespace ProjectWebGreeting.Controllers
{
    public class InfoAccountController : Controller
    {
        // GET: InfoAccount

        AccountInfoRepository accountInfo = new AccountInfoRepository();
        GreetingDatabaseEntities greeting = new GreetingDatabaseEntities();



        [HttpGet]
        public ActionResult Index(string username)
        {
            var account = accountInfo.findAccountInfo(username);
            if (account != null)
            {
                return View(account);
            }
            var session = (UserCommon)Session[CommonConstants.USER_SESSION];// nó trong đây nè

            if (session == null)
            {
                return RedirectToAction("Index", "ContactUs");
            }
            return View();

        }

        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult AddAccIF(Account accIF)// thang nay la tu form can duoc edit
        {



            if (ModelState.IsValid)
            {
                var session = (UserCommon)Session[CommonConstants.USER_SESSION];
                var account = accountInfo.findAccountInfo(session.UserName);
                if (account != null)
                {
                    account.firstName = accIF.firstName;
                    account.lastName = accIF.lastName;
                    account.mobile = accIF.mobile;
                    account.country = accIF.country;
                    account.gender = accIF.gender;
                    accountInfo.EditOject(account);
                }

                return Redirect("/");
            }
            return View("Index");
        }

    }
}