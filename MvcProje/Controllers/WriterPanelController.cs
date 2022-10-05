using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        public ActionResult WriterProfile()
        {
            return View();
        }
        //[AllowAnonymous]
        public ActionResult MyHeading()
        {
           
            var values = hm.GetListByWriter();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from i in cm.GetList() select new SelectListItem { Text = i.CategoryName, Value = i.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valuecategory;


            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.HeadingStatus = true;
            p.WriterID = 4;
            hm.HeadingAdd(p);

            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from i in cm.GetList() select new SelectListItem { Text = i.CategoryName, Value = i.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
    }
}