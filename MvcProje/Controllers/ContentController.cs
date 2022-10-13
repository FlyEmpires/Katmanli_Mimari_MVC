using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetAllContent(string p)
        {
            //var values = c.Contents.ToList();
           
            var values = cm.GetList(p);
            if (p == null)
            {
                values = cm.GetList();
            }
            return View(values.ToList());
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetByListHeadingID(id);
            return View(contentvalues);
        }
    }
}