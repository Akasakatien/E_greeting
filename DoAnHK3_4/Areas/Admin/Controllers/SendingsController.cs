using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnHK3_4.Models;
using DoAnHK3_4.Security;

namespace DoAnHK3_4.Areas.Admin.Controllers
{
    [MyAuthorize(Roles = "supperadmin,admin")]

    public class SendingsController : Controller
    {
        private GreetingDatabaseEntities db = new GreetingDatabaseEntities();

        // GET: Admin/Sendings
        public ActionResult Index()
        {
            var sendings = db.Sendings.Include(s => s.Account).Include(s => s.Greeting);
            return View(sendings.ToList());
        }

        // GET: Admin/Sendings/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Sending sending = db.Sendings.Find(id);
        //    if (sending == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sending);
        //}

        //// GET: Admin/Sendings/Create
        //public ActionResult Create()
        //{
        //    ViewBag.AccountId = new SelectList(db.Accounts, "id", "username");
        //    ViewBag.greetingId = new SelectList(db.Greetings, "id", "contents");
        //    return View();
        //}

        //// POST: Admin/Sendings/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "greetingId,AccountId,senderName,rersiveName,addressTo,customMessenger")] Sending sending)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Sendings.Add(sending);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.AccountId = new SelectList(db.Accounts, "id", "username", sending.AccountId);
        //    ViewBag.greetingId = new SelectList(db.Greetings, "id", "contents", sending.greetingId);
        //    return View(sending);
        //}

        //// GET: Admin/Sendings/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Sending sending = db.Sendings.Find(id);
        //    if (sending == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.AccountId = new SelectList(db.Accounts, "id", "username", sending.AccountId);
        //    ViewBag.greetingId = new SelectList(db.Greetings, "id", "contents", sending.greetingId);
        //    return View(sending);
        //}

        //// POST: Admin/Sendings/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "greetingId,AccountId,senderName,rersiveName,addressTo,customMessenger")] Sending sending)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(sending).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AccountId = new SelectList(db.Accounts, "id", "username", sending.AccountId);
        //    ViewBag.greetingId = new SelectList(db.Greetings, "id", "contents", sending.greetingId);
        //    return View(sending);
        //}

        //// GET: Admin/Sendings/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Sending sending = db.Sendings.Find(id);
        //    if (sending == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(sending);
        //}

        //// POST: Admin/Sendings/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Sending sending = db.Sendings.Find(id);
        //    db.Sendings.Remove(sending);
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
    }
}
