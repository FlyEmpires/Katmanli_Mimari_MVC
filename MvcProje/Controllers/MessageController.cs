using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class MessageController : Controller
    {
        // GET: Message
        Context ctx = new Context();
        MessageValidator messageValidator = new MessageValidator();

        MessageManager mm = new MessageManager(new EfMessageDal());
        [Authorize]
        public ActionResult Inbox(string p)
        {
            ViewBag.gelenmesaj = (from s in ctx.Messages select s.MessageContent).Count();

            var messagevalues = mm.GetListInbox(p);
            return View(messagevalues);
        }

        public ActionResult Sendbox(string p)
        {
            ViewBag.gelenmesaj = (from s in ctx.Messages select s.MessageContent).Count();

            var messagevalues = mm.GetListSendbox(p);
            return View(messagevalues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult results = messageValidator.Validate(p);
            if (results.IsValid)
            {
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
            //if (Request.Form["submitbutton1"] != null)
            //{
            //    mm.MessageAdd(p);
            //}
            //else if (Request.Form["submitButton2"] != null)
            //{
            //    // code for function 2
            //}
            //return View();
      
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


    }
}