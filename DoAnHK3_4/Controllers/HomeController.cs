using DoAnHK3_4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnHK3_4.Models;
using System.Web.Mvc;

namespace DoAnHK3_4.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryRepository iCategoryRepository = new CategoryRepository();
        private ICardRepository iCardRepository = new CardRepository();
        GreetingDatabaseEntities gre = new GreetingDatabaseEntities();
        // GET: Home
        public ActionResult Index()
        {
            
            var category = iCategoryRepository.findAllCategoryDetail();
            var Card = iCardRepository.findAll();           
            
            var cat = gre.Category_Details.FirstOrDefault(x => x.status.Equals("1"));
            int id = cat.id;
            var icate = iCategoryRepository.find(id);
            DateTime dateTimeEvent = cat.dateOfEvent.GetValueOrDefault();
            string dateEvent = String.Format("{0:dd/MM/yyyy}", dateTimeEvent);
            ViewBag.nameEvent = cat.name;
            ViewBag.date = dateEvent;
            ViewBag.greetings = icate.Greetings.ToList();
            ViewBag.countCard = Card.Count();
            ViewBag.countCate = category.Count();
            return View();
        }
    }
}