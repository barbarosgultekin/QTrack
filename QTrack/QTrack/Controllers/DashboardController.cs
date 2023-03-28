using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QTrack.Controllers
{
    public class DashboardController : Controller
    {
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        ProductManager pm = new ProductManager(new EfProductDal());
        QRManager qm = new QRManager(new EfQRDal());


        [HttpGet]
        public ActionResult Index()
        {
            var cv = cm.GetList().Count();
            var pv = pm.GetList().Count();
            var qv = qm.GetList().Count();

            ViewBag.cv = cv;
            ViewBag.pv = pv;
            ViewBag.qv = qv;
            return View();

        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}