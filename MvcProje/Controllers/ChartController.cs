using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MvcProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProje.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        Context ctx = new Context();

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart(Category c)
        {
            //ViewBag.a = (from s in ctx.Headings where s.CategoryID==8 select s.HeadingName).Count();
      var a= (from s in ctx.Headings where s.CategoryID==c.CategoryID select s.HeadingName).Count();
            return View(a);
          
        }
        public ActionResult Category()
        { 
            return Json(CategoryChartt(), JsonRequestBehavior.AllowGet);
        }
        public List<Chart> CategoryChartt()
        {
            List<Chart> cs = new List<Chart>();
            cs = ctx.Headings.Select(x => new Chart
            {
              categoryName=x.HeadingName,
              categoryCount=x.CategoryID


            }).ToList();
            return cs;           

        }
       

       
    }
}