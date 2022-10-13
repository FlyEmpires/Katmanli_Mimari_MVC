using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;
using System.Web.Security;
using DataAccessLayer.Concrete;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        AdminManager adm = new AdminManager(new EfAdminDal());
        WriterLoginManager wm = new WriterLoginManager(new EfWriterDal());
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin p)
        {
            LoginValidator loginvalidator = new LoginValidator();
            ValidationResult results = loginvalidator.Validate(p);
            var logininfo = adm.AdminLoginHata(p.AdminUserName, p.AdminPassword);
            
            var hata = adm.AdminHata(p.AdminUserName, p.AdminPassword);

            //if (results.IsValid)
            //{
            //    adm.AdminLogin(p);
            //    return RedirectToAction("Index", "AdminCategory");
            //}
            if (logininfo != null)
            {
                FormsAuthentication.SetAuthCookie(logininfo.AdminUserName, false);
                Session["AdminUserName"] = logininfo.AdminUserName;
                
                   
                return RedirectToAction("Index", "AdminCategory");
            }
            else if (hata!=null)
            {
                ViewBag.hata = "BOŞ";
                return View();
            }
            else if (hata==null)
            {
                ViewBag.hata = "Kullanıcı veya şifre Yanlış";
                return View();
            }
            else
                return View();
            //if(logininfo!=null)
            // {
            //     return RedirectToAction("Index", "AdminCategory");

            // }
            //else
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);

            //    }
            //}
            //else
            //{ return RedirectToAction("Index");
            //}
            //return View();
            
        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context ctx = new Context();
            //var writeruserinfo = ctx.Writers.FirstOrDefault(x=>x.WriterMail==p.WriterMail && x.WriterPassword==p.WriterPassword);
            var writeruserinfo =wm.GetWriter(p.WriterMail,p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
                else
            {

            return RedirectToAction("WriterLogin");
            }

        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}