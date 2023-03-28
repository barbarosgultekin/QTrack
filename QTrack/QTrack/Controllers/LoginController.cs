using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace QTrack.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        UserManager lm = new UserManager(new EfUserDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(User p)
        {
           
            var userinfo = lm.GetUser(p.USERNAME, p.PASSWORD);

            if (userinfo != null)
            {
                FormsAuthentication.SetAuthCookie(userinfo.USERNAME, false);
                Session["USERNAME"] = userinfo.USERNAME;
                return RedirectToAction("Index","Dashboard");
            }
            else
            {
                return View();    
            }
        }

        public ActionResult LogOut()
        {

            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Remove("USERNAME");
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}