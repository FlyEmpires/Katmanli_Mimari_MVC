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
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        WriterManager wm = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var HeadingValue = hm.GetList();
            return View(HeadingValue);
        }
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valuecategory = (from i in cm.GetList() select new SelectListItem { Text = i.CategoryName, Value = i.CategoryID.ToString() }).ToList();
            List<SelectListItem> valuewriter = (from i in wm.GetList() select new SelectListItem { Text = i.WriterName + " " + i.WriterSurname,Value=i.WriterID.ToString() }).ToList();

            ViewBag.vlw = valuewriter;
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            

            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            hm.HeadingAdd(p);
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {

            var headingvalue = hm.GetByID(id);
            if (headingvalue.HeadingStatus == true)
            {
                headingvalue.HeadingStatus = false;
                hm.HeadingDelete(headingvalue);
            }
            else
            {
                headingvalue.HeadingStatus = true;
                hm.HeadingDelete(headingvalue);
            }
            hm.HeadingDelete(headingvalue);
            return RedirectToAction("Index");
        }
      
    }
}