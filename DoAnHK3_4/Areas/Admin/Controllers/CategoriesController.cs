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

    public class CategoriesController : Controller
    {
        private GreetingDatabaseEntities db = new GreetingDatabaseEntities();

        // GET: Admin/Categories
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }



        // GET: Admin/Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name")] Category category)
        {
            var i = db.Categories.Count(acc => acc.name.Equals(category.name));
            if (ModelState.IsValid)
            {
                if (i<1)
                {
                    db.Categories.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Duplicate of category name");
            }

            return View(category);
        }

        // GET: Admin/Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name")] Category category)
        {
            var i = db.Categories.Count(acc => acc.name.Equals(category.name));

            if (ModelState.IsValid)
            {
                if (i <1)
                {
                    db.Entry(category).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("", "Duplicate of category name");

            }
            return View(category);
        }

        public ActionResult Delete(int id)
        {

            Category category = db.Categories.Find(id);
            //var CategoryDetails = category.Category_Details;
            //var getting = db.Greetings.Where(mvs=>mvs.)
            //var Greeting = db.Greetings.Where(mvs => mvs.Category_Details == CategoryDetails).AsEnumerable();
            try
            {
                //  foreach (var mvs in Greeting)
                //{
                //    var singleMvs = mvs;
                //    db.Greetings.Remove(singleMvs);
                //}
                //foreach (var mvs in CategoryDetails.ToList())
                //{
                //    foreach (var greeting in mvs.Greetings.ToList())
                //    {
                //        foreach (var sending in greeting.Sendings.ToList())
                //        {
                //            db.Sendings.Remove(sending);
                //        }

                //        db.Greetings.Remove(greeting);
                //    }
                //    db.Category_Details.Remove(mvs);
                //}
                if (category != null) db.Categories.Remove(category);
                db.SaveChanges();
            }
            catch
            {
                TempData["error"] = "Delete Fail";

            }
            return RedirectToAction("Index");
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            try
            {
                if (category != null) db.Categories.Remove(category);
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
