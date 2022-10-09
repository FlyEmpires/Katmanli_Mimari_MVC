using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager cm = new ContentManager(new EfContentDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        Context ctx = new Context();

        public ActionResult MyContent(string p )
        {
            p = (string)Session["WriterMail"];
            //var writeridinfo = ctx.Writers.Where(x=>x.WriterMail==p).Select(y=>y.WriterID).FirstOrDefault();
            var a = wm.GetByEmailID(p);
            //var contentvalues = cm.GetListByWriter(writeridinfo);
            var contentvalues = cm.GetListByWriter(a);
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];
            //var writeridinfo = ctx.Writers.Where(x=>x.WriterMail==p).Select(y=>y.WriterID).FirstOrDefault();
            var a = wm.GetByEmailID(mail);
            p.ContentStatus = true;

            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = a;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }       
    }
}