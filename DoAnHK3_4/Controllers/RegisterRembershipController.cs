using DoAnHK3_4.Common;
using DoAnHK3_4.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using DoAnHK3_4.Repository;
using System.Web.Mvc;

namespace DoAnHK3_4.Controllers
{
    public class RegisterRembershipController : Controller
    {

        PaymentRepository pay = new PaymentRepository();
        AccountInfoRepository account = new AccountInfoRepository();
        // GET: RegisterRembership

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registerpayment(int id)
        {
            if (id > 0)
            {
                Common.PaymentCommon cl = new Common.PaymentCommon();


                var c = pay.findService(id);
                ViewBag.price = c.price;
                ViewBag.id = c.name;
                PaymentCommon paymentcommon = new PaymentCommon();
                paymentcommon.id = c.id;
                Session.Add(Common.CommonConstants.ID_SESION, paymentcommon);
            }
            else
            {
                ViewBag.Error = "Choose Membership";
            }

            return View("Index");
        }
        public ActionResult Success()
        {
            var sessionID = (PaymentCommon)Session[CommonConstants.ID_SESION];
            var sessionUsername = (UserCommon)Session[CommonConstants.USER_SESSION];
            var service = pay.findService(sessionID.id);
            var acc = account.findAccount(sessionUsername.UserName);

            
            if (service != null)
            {


                if (ModelState.IsValid)
                {
                    DateTime today = System.DateTime.Now;
                    var user = new UserCommon();
                    var payments = new Payment();
                    payments.serviceId = service.id;
                    payments.accountId = acc.id;
                    payments.expiryDate = today.AddMonths(service.name);
                    payments.amount = service.price;
                    payments.Status = true;
                    user.Payment = false;
                    
                    //Session.Add(CommonConstants.USER_SESSION, user);
                    pay.AddPayment(payments);
                }
                
            }
            return View("Success");
        }



    }
}