using DoAnHK3_4.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using DoAnHK3_4.Models;

namespace DoAnHK3_4.Areas.Admin.Controllers
{
    [MyAuthorize(Roles = "supperadmin,admin")]
    

    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ChartPie()
        {
            var db = new GreetingDatabaseEntities();
            var xValueArrayList = new ArrayList();
            var yValueArrayList = new ArrayList();
            var resultsPayments = db.Payments.Select(c => c);
            resultsPayments.ToList().ForEach(rs=>xValueArrayList.Add(rs.Service.name));
            resultsPayments.ToList().ForEach(rs => yValueArrayList.Add(rs.amount.ToString()));
            new Chart(width: 800, height: 600, theme: ChartTheme.Blue)
                .AddTitle("Desktop Amount In E Greeting Payment , Jul-2017")
                .AddSeries("Default", chartType:"Pie", xValue:xValueArrayList, xField:"Service", yValues:yValueArrayList, yFields:"Amount")
                .AddLegend(title:"Service",name:"Amount")
                .SetXAxis(title:"Service")
                
                
                .Write("bmp");
            return null;


        }
    }
}