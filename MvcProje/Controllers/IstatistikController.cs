using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MvcProje.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        Category cm = new Category();
        Writer wr = new Writer();
        Context ctx = new Context();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Liste()
        {
            ViewBag.gelenmesaj = (from s in ctx.Messages select s.MessageContent).Count();
            ViewBag.kategori = (from s in ctx.Categories select s.CategoryName).Count(); //çalışıyor
            ViewBag.baslik = (from s in ctx.Headings where s.CategoryID == 13 select s.HeadingName).Count(); //çalışıyor
            ViewBag.sayi = (from s in ctx.Writers where s.WriterName.Contains("a") select s.WriterName).Count(); //çalışıyor
            var msg = (from s in ctx.Categories where s.CategoryStatus == false select s.CategoryStatus).Count();

            ViewBag.msg = (from s in ctx.Categories where s.CategoryStatus == true select s.CategoryStatus).Count() - msg; //çalışıyor
            ViewBag.enfazla = (from s in ctx.Categories where s.CategoryID == 5 select s.CategoryName).FirstOrDefault();

            //ViewBag.yazaradı = (from c in ctx.Writers where c.WriterName.Contains("a") select new Listelemee { WriterName = c.WriterName }).AsEnumerable().Select(x => new Listelemee { WriterName = x.WriterName }).ToList();

            //var yazarlar = ctx.Writers.Select(x => new Listelemee { WriterName = x.WriterName }).ToList();
            //var yazarlar = ctx.Writers.Where(x => x.WriterName == "Talha").Select(xx => new Listelemee { WriterName = xx.WriterName,WriterSurname=xx.WriterSurname }).ToList();
            //ViewBag.msg = yazarlar;
            //var yazarlar = (from r in ctx.Writers.Where(x => x.WriterName == "Talha") select r).DefaultIfEmpty();



            //ViewBag.msg = ctx.Categories.First(x => x.CategoryID == 2).CategoryName; //çalışıyor

            //ViewBag.yazaradı = ctx.Writers.Where(x => x.WriterName);
            //ViewBag.msg= (from c in ctx.Writers where c.WriterName.Contains("a") select new Listelemee { WriterName = c.WriterName }).FirstOrDefault();
            //ViewBag.msg = (from c in ctx.Writers where c.WriterName.Contains("T") select c).ToString();
            //ViewBag.yazaradı = ctx.Writers.Where(x => x.WriterName.StartsWith("T")).ToList();

            //ViewBag.yazaradı = (from c in ctx.Writers where c.WriterName.Contains("a") select new Writer { WriterName = c.WriterName, WriterSurname = c.WriterSurname }).FirstOrDefault();

            //ViewBag.yazaradı = (from c in ctx.Writers where c.WriterName.Contains("a") select new Listelemee { WriterName = c.WriterName }).ToList();
            //Listeleme();

            return View();
        }



        //public  List<Listelemee> Listeleme()
        //{
        //  return( from p in ctx.Writers where p.WriterName.StartsWith("T") select new Listelemee { WriterName=p.WriterName}).ToList();

        //    //ViewBag.yazaradı= (from p in ctx.Writers where p.WriterName.Contains("a") select new Listelemee { WriterName = p.WriterName }).ToList();
         

                
        //}
    }
}
        



