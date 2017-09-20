using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnHK3_4.Repository;
using DoAnHK3_4.Models;
using DoAnHK3_4.Common;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;
using DoAnHK3_4.ViewModels;

namespace DoAnHK3_4.Controllers
{
    public class CardsController : Controller
    {
        private ICategoryRepository iCategoryRepository = new CategoryRepository();
        private ICardRepository iCardRepository = new CardRepository();
        private ISendingRepository iSendingRepository = new SendingRepository();
        

        // GET: Cards
        public ActionResult Index()
        {
            ViewBag.latestCards = iCardRepository.LatestCards(12);
            return View();
        }
        public ActionResult Category(int id)
        {
            var categoryDetail = iCategoryRepository.find(id);
            ViewBag.category = categoryDetail;
            ViewBag.greetings = iCategoryRepository.find(id).Greetings.ToList();
            return View("Category");
        }
        [HttpGet]
        public ActionResult Personalize(int id)
        {
            CardCommon videoPhoto = new CardCommon();
            UserCommon user = new UserCommon();
            user.Id = id;

            Session.Add(Common.CommonConstants.ID_SESION, user);
            var card = iCardRepository.find(id);
            //ViewBag.card = card;

            videoPhoto.photo = card.photo;
            videoPhoto.video = card.video;
            Session.Add(CommonConstants.CARD_SESSION, videoPhoto);
            //Item item = new Item{ greeting = iCardRepository.find(id)};
            //Session[Common.CommonConstants.SENDING_SESSION] = item;
            return View("Personalize");
        }   
        [HttpPost]
        public ActionResult Personalize(SendingViewModel sending)
        {
            Sending sed = new Sending();
            var find = new AccountInfoRepository();
           
            var user = (UserCommon)Session[CommonConstants.USER_SESSION];
            var id = (UserCommon)Session[CommonConstants.ID_SESION];
            
            if (ModelState.IsValid)
            {
                
                if (user == null)
                {
                   
                    return RedirectToAction("CheckLogin");
                }
                else
                {
                    // sai ne 
                    var account = find.findAccount(user.UserName);                    
                    sed.AccountId = account.id;
                    sed.greetingId = id.Id;
                    sed.senderName = sending.senderName;
                    sed.rersiveName = sending.rersiveName;
                    sed.customMessenger = sending.customMessenger;
                    sed.addressTo = sending.addressTo;

                    ViewBag.senderName = sed.senderName;
                    ViewBag.recipient = sed.rersiveName;
                    ViewBag.message = sed.customMessenger;
                    var card = iCardRepository.find(id.Id);
                    ViewBag.photo = card.photo;
                    //iSendingRepository.create(sed);

                    Session.Add(Common.CommonConstants.SENDING_SESSION, sed);
                    return View("CheckOutAndSend");
                }
            }
            return View(sending);
            
            
        }
        public ActionResult DetailSender(string Recipient, string email)
        {           
            return View("DetailSender");
        }

        
        public ActionResult CheckLogin()
        {
            //CardCommon videoPhoto = new CardCommon();
            //UserCommon user = new UserCommon();
            //var video = Session[CommonConstants.CARD_SESSION];
            ////user.Id = id;

            ////Session.Add(Common.CommonConstants.ID_SESION, user);
            ////var card = iCardRepository.find(id);
            ////ViewBag.card = card;

            //videoPhoto.photo = card.photo;
            //videoPhoto.video = card.video;
            //Session.Add(CommonConstants.CARD_SESSION, videoPhoto);
            //Item item = new Item{ greeting = iCardRepository.find(id)};
            //Session[Common.CommonConstants.SENDING_SESSION] = item;
            
            return View("CheckLogin");
        }   
        [HttpPost]
        public ActionResult CheckOutAndSend()
        {
            //var id = (UserCommon)Session[CommonConstants.ID_SESION];
            //var send = (Sending)Session[CommonConstants.SENDING_SESSION];
            
            ////sed.AccountId = send.id;
            ////sed.greetingId = send.greetingId;
            ////sed.senderName = send.senderName;
            ////sed.rersiveName = send.rersiveName;
            ////sed.customMessenger = send.customMessenger;
            ////sed.addressTo = send.addressTo;
            //iSendingRepository.create(send);
            ////var card = iCardRepository.find(id.Id);
            ////ViewBag.senderName = send.senderName;
            ////ViewBag.recipient = send.rersiveName;
            ////ViewBag.message = send.customMessenger;
            ////ViewBag.card = card.photo;
            //////ViewBag.infoSending = send;
            return View("CheckOutAndSend");
        }    
        [HttpPost]
        public ActionResult sendMail()
        {
            var user = (UserCommon)Session[CommonConstants.USER_SESSION];
            var id = (UserCommon)Session[CommonConstants.ID_SESION];
            var send = (Sending)Session[CommonConstants.SENDING_SESSION];            
            var card = iCardRepository.find(id.Id);
            if(user.Payment == false)
            {
                return RedirectToAction("Index", "RegisterRembership");
            }
            iSendingRepository.create(send);        //Save object Sending into database

            if (ModelState.IsValid)
            {
                string content = string.Empty;
                string title = send.senderName + " has sent an e-card from Aptech of Aprotrain";
                using (StreamReader reader = new StreamReader(Server.MapPath("~/Client/ClientGreeting.html")))
                {
                    content = reader.ReadToEnd();
                }
                string photo = null;
                string url = null;
                
                if (card.video != null)
                {
                    photo = "C:/Users/akasa/Documents/visual studio 2015/Projects/DoAnHK3_4/DoAnHK3_4/Content/uploadedgreeting/" + card.photo;
                    
                    content = content.Replace("{SenderName}", send.senderName);
                    content = content.Replace("{Recipient}", send.rersiveName);
                    content = content.Replace("{Message}", send.customMessenger);
                    content = content.Replace("{Url}", card.url);
                    new MailHelper().SenMail(send.addressTo, title, content, photo);
                 
                }
                else
                {
                    photo = "C:/Users/akasa/Documents/visual studio 2015/Projects/DoAnHK3_4/DoAnHK3_4/Content/uploadedgreeting/" + card.photo;
                    url = "#m_5925492875219722956_";
                    content = content.Replace("{SenderName}", send.senderName);
                    content = content.Replace("{Recipient}", send.rersiveName);
                    content = content.Replace("{Message}", send.customMessenger);
                    content = content.Replace("{Url}", url);
                    new MailHelper().SenMail(send.addressTo, title, content, photo);
                }
               
                 
            }
            return RedirectToAction("Index", "Home");
        }

       
    }
}