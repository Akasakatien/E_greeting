using Facebook;
using DoAnHK3_4.ViewModels;
using DoAnHK3_4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DoAnHK3_4.Common;
using DoAnHK3_4.Repository;

namespace ProjectWebGreeting.Controllers
{
    public class ContactUsController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        string firstname = "";
        string gender = "";
        string lastname = "";
        string email = "";
        string id = "";
        string middleName = "";


        AccountInfoRepository acccount = new AccountInfoRepository();
        GreetingDatabaseEntities greeting = new GreetingDatabaseEntities();
        PaymentRepository pay = new PaymentRepository();

        // GET: ContactUs
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["Fbappid"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });
            return Redirect(loginUrl.AbsoluteUri);
        }


        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();

            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppID"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {

                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name,id,last_name,middle_name,email,gender,birthday");
                id = me.id;
                email = me.email;
                firstname = me.first_name;
                middleName = me.middle_name;
                lastname = me.last_name;
                gender = me.gender;
                var user = new UserCommon();

                user.UserName = id;
                user.FullName = lastname + " " + middleName + "" + firstname;
                user.FaceBook = true;

                DateTime today = System.DateTime.Now;
                var account = greeting.Accounts.SingleOrDefault(x => x.username.Equals(id));
                if (acccount.findAccount(id) == null)
                {

                   
                       
                        Account ac = new Account();
                        ac.username = id;
                        ac.lastName = lastname;
                        ac.firstName = firstname;
                        ac.gender = gender;
                        ac.question = "Not Question ";
                        ac.answer = "Not Answer";
                        ac.roldId = 1;
                        ac.facebook = true;
                        Session.Add(CommonConstants.USER_SESSION, user);

                        greeting.Configuration.ValidateOnSaveEnabled = false;
                        greeting.Accounts.Add(ac);

                        greeting.SaveChanges();
                        return Redirect("/");
                   
                }
                else
                {

                    var find = pay.findPay(account.id);
                    if (find != null)
                    {

                        var daysub = find.expiryDate.GetValueOrDefault().Subtract(today);
                        int day = Convert.ToInt32(daysub.TotalDays);
                        if (day == 0)
                        {
                            find.Status = false;
                            pay.EditPayment(find);
                        }
                        user.Payment = find.Status;
                    }
                    Session.Add(CommonConstants.USER_SESSION, user);
                }




            }
            return Redirect("/");
        }

        [HttpPost]
        public ActionResult LoginForAccount(AccountViewModels1 acc)
        {


            if (ModelState.IsValid)
            {
                var user = new UserCommon();
                string pas = EncryptMD5.Encrypt(acc.password);
                    var account = greeting.Accounts.SingleOrDefault(x => x.username.Equals(acc.username) && x.password.Equals(pas));

                if (account != null)
                {
                    var find = pay.findPay(account.id);
                    if (find != null)
                    {
                        DateTime today = System.DateTime.Now;
                        var daysub = find.expiryDate.GetValueOrDefault().Subtract(today);
                        int day = Convert.ToInt32(daysub.TotalDays);
                        if (day <= 0)
                        {
                            find.Status = false;
                            pay.EditPayment(find);
                        }
                        user.Payment = find.Status;
                    }

                    user.UserName = account.username;
                    user.FullName = account.username;
                    user.FaceBook = false;
                    Session.Add(CommonConstants.USER_SESSION, user);

                    return RedirectToAction("Index", "Home");


                }
                else
                {
                    ModelState.AddModelError("", "Email or Password not wrong");

                }
            }
            else
            {
                ModelState.AddModelError("", "Email and PassWord not Empty");
            }
          


            return View("Index");
        }
        public ActionResult Logout()
        {


            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }


    }
}