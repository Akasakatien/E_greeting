using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnHK3_4.Models;
using DoAnHK3_4.ViewModels;
using DoAnHK3_4.Common;
using System.Data.Entity.SqlServer;
using DoAnHK3_4.Security;

namespace DoAnHK3_4.Areas.Admin.Controllers
{
    [MyAuthorize(Roles = "superadmin")]
    public class AccountsController : Controller
    {
        private GreetingDatabaseEntities db = new GreetingDatabaseEntities();

        // GET: Admin/Accounts
        public ActionResult Index()
        {

            var accounts = db.Accounts.Include(a => a.Role);
            //return View(model);
            return View(accounts.ToList());
        }

        // GET: Admin/Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Admin/Accounts/Create
        public ActionResult Create()
        {

            ViewBag.roldId = new SelectList(db.Roles, "id", "name");
            return View();
        }

        // POST: Admin/Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,username,password,question,answer,roldId,firstName,lasName,gender,country,mobile,address")] Account account)
        {
            var i = db.Accounts.Count(acc => acc.username.Equals(account.username));
            if (ModelState.IsValid)
            {
                if (i < 1)
                {

                    AccountViewModels avm = new AccountViewModels();
                    avm.accountView = new Account();
                    avm.accountView.username = account.username;
                    avm.accountView.password = EncryptMD5.Encrypt(account.password);
                    avm.accountView.question = account.question;
                    avm.accountView.answer = account.answer;
                    avm.accountView.roldId = account.roldId;
                    avm.accountView.firstName = account.firstName;
                    avm.accountView.lastName = account.lastName;
                    avm.accountView.gender = account.gender;
                    avm.accountView.country = account.country;
                    avm.accountView.mobile = account.mobile;
                    avm.accountView.address = account.address;


                    db.Accounts.Add(avm.accountView);
                    db.SaveChanges();
                    return View("Index");

                }
                ModelState.AddModelError("", "UserName Has been used");
            }

            ViewBag.roldId = new SelectList(db.Roles, "id", "name", account.roldId);
            return View(account);
        }

        // GET: Admin/Accounts/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account.facebook == true) {
                TempData["error"] = "Can't Edit Account Login By Facebook";
                return RedirectToAction("Index");
            }else if (account.password != null)
            {
                account.password = Common.EncryptMD5.Decrypt(account.password);

            }else if (account == null)
            {
                return HttpNotFound();
            }
            ViewBag.roldId = new SelectList(db.Roles, "id", "name", account.roldId);
            return View(account);
        }

        // POST: Admin/Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[MultipleButton(Name = "action", Argument = "Edit")]

        public ActionResult Edit([Bind(Include = "username,password,question,answer,roldId,firstName,lasName,gender,country,mobile,address")] Account account)
        {
            //ProjectWebGreeting.Common.EncryptMD5.Decrypt(account.password);
            if (ModelState.IsValid)
            {
                AccountViewModels avm = new AccountViewModels()
                {


                    accountView = new Account()
                    {
                        username = account.username,
                        password = EncryptMD5.Encrypt(account.password),
                        question = account.question,
                        answer = account.answer,
                        roldId = account.roldId,
                        firstName = account.firstName,
                        lastName = account.lastName,
                        gender = account.gender,
                        country = account.country,
                        mobile = account.mobile,
                        address = account.address
                   
                    }
                };
                db.Entry(avm.accountView).State =System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.roldId = new SelectList(db.Roles, "id", "name", account.roldId);
            return View(account);
        }
        public ActionResult Delete(int? id)
        {
            var account = db.Accounts.Find(id);
            try
            {
                //foreach(var mvs in payments)
                //{
                //    var singleMvs = mvs;
                //    db.Payments.Remove(singleMvs);
                //}
                //foreach (var mvs in sendings)
                //{
                //    var singleMvs = mvs;
                //    db.Sendings.Remove(singleMvs);
                //}
                if (account != null)
                    db.Accounts.Remove(account);
                db.SaveChanges();

            }
            catch
            {
                TempData["error"] = "Delete Fail";

            }
            return RedirectToAction("Index");



        }

        //// GET: Admin/Accounts/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Account account = db.Accounts.Find(id);
        //    if (account == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(account);
        //}

        //// POST: Admin/Accounts/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int? id)
        //{
        //    Account account = db.Accounts.Find(id);
        //    db.Accounts.Remove(account);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //[HttpGet]
        //public ActionResult Login()
        //{
        //    return View("Login");
        //}
        //[HttpPost]
        //public ActionResult Login(Account  account)
        //{
        //    var pas = EncryptMD5.Encrypt(account.password);
        //    var result = db.Accounts.Count(a => a.username.Equals(account.username) && a.password.Equals(pas));
        //    if (result > 0)
        //    {

        //        Session["username"] = account.username;
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.error = "Account's Invalid";
        //        return View("Login", new Account());
        //    }
        //}
        //public ActionResult Logout()
        //{
        //    Session.Remove("username");
        //    return RedirectToAction("Login", "Accounts");
        //}
        [HttpGet]
        public ActionResult ChangeProfile()
        {
            var keyword = MySession .Username;
            var account = db.Accounts.FirstOrDefault(a => a.username.Contains(keyword));
            account.password = Common.EncryptMD5.Decrypt(account.password);

            return View("ChangeProfile", account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeProfile(Account account)
        {

            AccountViewModels avm = new AccountViewModels()
            {


                accountView = new Account()
                {
                    id=account.id,
                    username = MySession.Username,

                    password = EncryptMD5.Encrypt(account.password),
                    question = account.question,
                    answer = account.answer,
                    roldId = account.roldId,
                    firstName = account.firstName,
                    lastName = account.lastName,
                    gender = account.gender,
                    country = account.country,
                    mobile = account.mobile,
                    address = account.address

                }
            };
            db.Entry(avm.accountView).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View("Index");
        }

        [HttpGet]
        public ActionResult MyProfile()
        {
            var keyword = MySession.Username;
            var account = db.Accounts.FirstOrDefault(a => a.username.Contains(keyword));
            account.password = Common.EncryptMD5.Decrypt(account.password);

            ViewBag.roldId = new SelectList(db.Roles, "id", "name", account.roldId);
            return View("MyProfile", account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MyProfile(Account account)
        {

            AccountViewModels avm = new AccountViewModels()
            {


                accountView = new Account()
                {
                    id = account.id,
                    username = MySession.Username,
                    password = EncryptMD5.Encrypt(account.password),
                    question = account.question,
                    answer = account.answer,
                    roldId = account.roldId,
                    firstName = account.firstName,
                    lastName = account.lastName,
                    gender = account.gender,
                    country = account.country,
                    mobile = account.mobile,
                    address = account.address

                }
            };
            db.Entry(avm.accountView).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }



    }
}
