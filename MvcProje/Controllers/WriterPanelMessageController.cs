using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage

        MessageValidator messageValidator = new MessageValidator();

        MessageManager mm = new MessageManager(new EfMessageDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Inbox()
        {
          string  p = (string)Session["WriterMail"];

            var messagevalues = mm.GetListInbox(p);
            return View(messagevalues);
        }
        public ActionResult Sendbox()
        {
            //ViewBag.gelenmesaj = (from s in ctx.Messages select s.MessageContent).Count();
            string p = (string)Session["WriterMail"];

            var messagevalues = mm.GetListSendbox(p);
            return View(messagevalues);
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }

        public ActionResult GetSendboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];

            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());

                mm.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public PartialViewResult SolMenu()
        {
            return PartialView();
        }
    }
}