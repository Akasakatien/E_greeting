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

namespace DoAnHK3_4.Areas.Admin.Controllers
{
    [MyAuthorize(Roles = "supperadmin,admin")]

    public class GreetingsController : Controller
    {
        private GreetingDatabaseEntities db = new GreetingDatabaseEntities();

        // GET: Admin/Greetings
        public ActionResult Index()
        {
            var greetings = db.Greetings.Include(g => g.Category_Details);
            return View(greetings.ToList());
        }

        private bool isValidContentType(string contentType)
        {
            return contentType.Equals("image/png") || contentType.Equals("image/jpeg")||
            contentType.Equals("image/jpg")||
            contentType.Equals("image/gif");

        }
        private bool isValidContentTypeVideo(string contentType)
        {
            return contentType.Equals("video/mp4") || contentType.Equals("video/webm");

        }

        // GET: Admin/Greetings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Greeting greeting = db.Greetings.Find(id);
            if (greeting == null)
            {
                return HttpNotFound();
            }
            return View(greeting);
        }

        // GET: Admin/Greetings/Create
        public ActionResult Create()
        {

            ViewBag.categoryDetailsID = new SelectList(db.Category_Details, "id", "name");
            return View();
        }

        // POST: Admin/Greetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Greeting greeting, HttpPostedFileBase photo, HttpPostedFileBase video)
        {
            if (ModelState.IsValid)
            {
                if (!isValidContentType((photo.ContentType)))
                {
                    ViewBag.Error = "Only JPG, JPEG, PNG & Gif files are allowed";
                    ViewBag.categoryDetailsID = new SelectList(db.Category_Details, "id", "name");
                    return View("Create");
                }
                if (video != null && !isValidContentTypeVideo((video.ContentType)))
                {
                    ViewBag.Error = "Only MP4 and WEBM files are allowed";
                    ViewBag.categoryDetailsID = new SelectList(db.Category_Details, "id", "name");
                    return View("Create");
                }
                else
                {
                    string path = Server.MapPath("~/Content/uploadedgreeting/" + photo.FileName);
                    photo.SaveAs(path);

                    if (video !=null)
                    {
                        string pathVid = Server.MapPath("~/Content/uploadedgreeting/video/" + video.FileName);
                        video.SaveAs(pathVid);

                    }

                    GreetingViewModel greetingViewModel = new GreetingViewModel();
                    greetingViewModel.greeting = new Greeting();

                    greetingViewModel.greeting.photo = photo.FileName;
                    if(video != null)
                    {
                        greetingViewModel.greeting.video = video.FileName;


                    }

                    greetingViewModel.greeting.categoryDetailsID = greeting.categoryDetailsID;



                    db.Greetings.Add(greetingViewModel.greeting);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
               
              
               
            }

            ViewBag.categoryDetailsID = new SelectList(db.Category_Details, "id", "name", greeting.categoryDetailsID);
            return View(greeting);
        }

        // GET: Admin/Greetings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Greeting greeting = db.Greetings.Find(id);
            ViewBag.CurrentPhoto = greeting.photo;
            if (greeting == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryDetailsID = new SelectList(db.Category_Details, "id", "name", greeting.categoryDetailsID);
            return View(greeting);
        }

        // POST: Admin/Greetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Greeting greeting, HttpPostedFileBase photo, HttpPostedFileBase video)
        {
            if (ModelState.IsValid)
            {
                GreetingViewModel greetingViewModel = new GreetingViewModel();
                greetingViewModel.greeting = new Greeting()
                {
                    id = greeting.id,

                    categoryDetailsID = greeting.categoryDetailsID,
                    photo = greeting.photo
                };
                if (photo!=null)
                {
                    string path = Server.MapPath("~/Content/uploadedgreeting/" + photo.FileName);
                    photo.SaveAs(path);


                }
                if (video != null)
                {
                    string pathVid = Server.MapPath("~/Content/uploadedgreeting/video/" + video.FileName);
                    video.SaveAs(pathVid);


                }
                greetingViewModel.greeting.photo = photo.FileName.ToString();


                db.Entry(greetingViewModel.greeting).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryDetailsID = new SelectList(db.Category_Details, "id", "name", greeting.categoryDetailsID);
            return View(greeting);
        }

    

        // POST: Admin/Greetings/Delete/5

        public ActionResult Delete(int id)
        {
            Greeting greeting = db.Greetings.Find(id);
            var sending = db.Sendings.Where(r => r.greetingId == greeting.id).AsEnumerable();
            try
            {
                if (greeting != null) db.Greetings.Remove(greeting);
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
