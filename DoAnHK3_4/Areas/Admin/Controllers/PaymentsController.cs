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

    public class PaymentsController : Controller
    {
        private GreetingDatabaseEntities db = new GreetingDatabaseEntities();

        // GET: Admin/Payments
        public ActionResult Index()
        {
            var payments = db.Payments.Include(p => p.Account).Include(p => p.Service);
            return View(payments.ToList());
        }

        public ActionResult PaymentForAccount(int id)
        {
            var payments = db.Payments.Where(p=>p.accountId==id);

            return View("PaymentForAccount", payments.ToList());
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
