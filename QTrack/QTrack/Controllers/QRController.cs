using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QTrack.Controllers
{
    public class QRController : Controller
    {
        QRManager qm = new QRManager(new EfQRDal());
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        ProductManager pm = new ProductManager(new EfProductDal());

        //[Authorize(Roles="Admin")]
        public ActionResult Index()
        {
            var QRvalue = qm.GetList();
            return View(QRvalue);
        }
        public ActionResult AddQR(QR p)
        {
            QRValidator QRvalid = new QRValidator();
            ValidationResult results = QRvalid.Validate(p);

            if (results.IsValid)
            {
                qm.QRAdd(p);
                TempData["QRtoastr"] = "Added";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    TempData["QRtoastr"] = "Error";
                }
            }
           
            return RedirectToAction("Index");
        }
        public PartialViewResult QRPartial()            
        {
            List<SelectListItem> valuecompany = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CNAME,
                                                     Value = x.COMPANYID.ToString()

                                                 }).ToList();

            List<SelectListItem> valueproduct = (from x in pm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PNAME,
                                                     Value = x.PRODUCTID.ToString()

                                                 }).ToList();

            ViewBag.cv = valuecompany;
            ViewBag.pv = valueproduct;

            return PartialView();
        }

        [HttpGet]
        public ActionResult EditQR(int id)
        {
            List<SelectListItem> valuecompany = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CNAME,
                                                     Value = x.COMPANYID.ToString()

                                                 }).ToList();

            List<SelectListItem> valueproduct = (from x in pm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PNAME,
                                                     Value = x.PRODUCTID.ToString()

                                                 }).ToList();

            ViewBag.cv = valuecompany;
            ViewBag.pv = valueproduct;

            var QRvalue = qm.GetById(id);
            return View(QRvalue);
        }
        [HttpPost]
        public ActionResult EditQR(QR p)
        {
            QRValidator QRvalid = new QRValidator();
            ValidationResult results = QRvalid.Validate(p);

            if (results.IsValid)
            {
                qm.QRUpdate(p);
                TempData["QRtoastr"] = "Added";
                return RedirectToAction("Index", "QR");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    TempData["QRtoastr"] = "Error";
                }
            }
            
            return RedirectToAction("Index","QR");
        }

        public PartialViewResult QRCreate( )
        {

            return PartialView();
        }

    }
}