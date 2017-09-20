using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAnHK3_4.Models;

namespace DoAnHK3_4.Areas.Admin.Controllers
{
    public class ServicesController : Controller
    {
        private GreetingDatabaseEntities db = new GreetingDatabaseEntities();

        // GET: Admin/Services
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }



        // GET: Admin/Services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,price")] Service service)
        {
            var i = db.Services.Count(acc => acc.name.Equals(service.name));

            if (ModelState.IsValid)
            {
                if (i<1)
                {
                    db.Services.Add(service);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Duplicate of category name");

            }

            return View(service);
        }

        // GET: Admin/Services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Admin/Services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,price")] Service service)
        {
            if (ModelState.IsValid)
            {
                var i = db.Services.Count(acc => acc.name.Equals(service.name));
                if (i < 1)
                {
                    db.Entry(service).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                

                ModelState.AddModelError("", "Duplicate of category name");
            }
            return View(service);
        }



        // POST: Admin/Services/Delete/5
  
        public ActionResult Delete(int id)
        {
            Service service = db.Services.Find(id);
            var payments = db.Payments.Where(mvs => mvs.accountId == service.id).AsEnumerable();

            try
            {
                foreach (var mvs in payments)
                {
                    var singleMvs = mvs;
                    db.Payments.Remove(singleMvs);
                }
                db.Services.Remove(service);
                db.SaveChanges();
            }
            catch
            {
                TempData["error"] = "Delete Fail";
            }
            return RedirectToAction("Index");
        }

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
