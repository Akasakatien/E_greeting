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
using DoAnHK3_4.ViewModels;
using DoAnHK3_4.Models;


namespace DoAnHK3_4.Areas.Admin.Controllers
{
    [MyAuthorize(Roles = "supperadmin,admin")]

    public class Category_DetailsController : Controller
    {
        private GreetingDatabaseEntities db = new GreetingDatabaseEntities();

        // GET: Admin/Category_Details
        public ActionResult Index()
        {
            var category_Details = db.Category_Details.Include(c => c.Category);
            return View(category_Details.ToList());
        }

        // GET: Admin/Category_Details/Details/5


        // GET: Admin/Category_Details/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.Categories, "id", "name");
            return View();
        }

        // POST: Admin/Category_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,categoryID,dateOfEvent")] Category_Details category_Details)
        {
            var i = db.Category_Details.Count(acc => acc.name.Equals(category_Details.name));

            if (ModelState.IsValid)
            {
                if (i<1)
                {
                    Category_DetailsViewModel category_DetailsViewModel = new Category_DetailsViewModel();
                    category_DetailsViewModel.category_details = new Category_Details();
                    category_DetailsViewModel.category_details.id = category_Details.id;
                    category_DetailsViewModel.category_details.name = category_Details.name;

                    category_DetailsViewModel.category_details.dateOfEvent = category_Details.dateOfEvent;

                    category_DetailsViewModel.category_details.status = category_Details.status;
                    category_DetailsViewModel.category_details.categoryID = category_Details.categoryID;




                    db.Category_Details.Add(category_DetailsViewModel.category_details);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "CategoryDetail Has been used");
            }
            ViewBag.categoryID = new SelectList(db.Categories, "id", "name", category_Details.categoryID);
            return View(category_Details);
        }

        // GET: Admin/Category_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Details category_Details = db.Category_Details.Find(id);
            if (category_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.Categories, "id", "name", category_Details.categoryID);
            return View(category_Details);
        }

        // POST: Admin/Category_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,categoryID,dateOfEvent")] Category_Details category_Details)
        {
            //var i = db.Category_Details.Count(acc => acc.name.Equals(category_Details.name));

            if (ModelState.IsValid)
            {
                //if (i < 1)
                //{
                    db.Entry(category_Details).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                //}
                //ModelState.AddModelError("", "CategoryDetail Has been used");

            }
            ViewBag.categoryID = new SelectList(db.Categories, "id", "name", category_Details.categoryID);
            return View(category_Details);
        }

 

        // POST: Admin/Category_Details/Delete/5
        public ActionResult Delete(int id)
        {
            Category_Details category_Details = db.Category_Details.Find(id);
               var Greetings = db.Greetings.Where(mvs => mvs.categoryDetailsID == category_Details.id).AsEnumerable();

            try
            {
                //foreach (var mvs in Greetings.ToList())
                //{
                //    foreach(var sending in mvs.Sendings.ToList())
                //    {
                //        db.Sendings.Remove(sending);
                //    }

                //    db.Greetings.Remove(mvs);
                //}
                if (category_Details != null) db.Category_Details.Remove(category_Details);
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
