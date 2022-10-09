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
        WriterManager wm = new WriterManager(new EfWriterDal());
        int id;
        public ActionResult WriterProfile()
        {
            return View();
        }
        //[AllowAnonymous]
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
           var a = wm.GetByEmailID(p);
            id = a;
            var values = hm.GetListByWriter(a);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            ViewBag.d = id;
            List<SelectListItem> valuecategory = (from i in cm.GetList() select new SelectListItem { Text = i.CategoryName, Value = i.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valuecategory;


            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string deger= (string)Session["WriterMail"];
            var a = wm.GetByEmailID(deger);
            ViewBag.d = a;
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.HeadingStatus = true;
            p.WriterID = a;

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
            return RedirectToAction("MyHeading");
        }
        public ActionResult AllHeading()
        {
            var values = hm.GetList();
            return View(values);
        }
    }
}