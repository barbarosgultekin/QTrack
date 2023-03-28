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
    public class ProductController : Controller
    {
        ProductManager pm = new ProductManager(new EfProductDal());
        ProductTypeManager ptm = new ProductTypeManager(new EfProductTypeDal());
        public ActionResult Index()
        {
            var productvalue = pm.GetList();
            return View(productvalue);
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            ProductValidator productvalid = new ProductValidator();
            ValidationResult results = productvalid.Validate(p);

            if (results.IsValid)
            {
                pm.ProductAdd(p);
                TempData["protoastr"] = "Added";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    TempData["protoastr"] = "Error";
                }
            }            
            return RedirectToAction("Index");
        }
        public PartialViewResult ProductPartial()
        {
            List<SelectListItem> valueproduct = (from x in ptm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PTYPE.ToString(),
                                                     Value = x.PTYPEID.ToString()

                                                 }).ToList();

            ViewBag.vp = valueproduct;
            return PartialView();
        }
        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            List<SelectListItem> valueproduct = (from x in ptm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.PTYPE.ToString(),
                                                     Value = x.PTYPEID.ToString()

                                                 }).ToList();

            ViewBag.vp = valueproduct;
            var productvalue = pm.GetById(id);
            return View(productvalue);
        }

        [HttpPost]
        public ActionResult EditProduct(Product p)
        {
            ProductValidator productvalid = new ProductValidator();
            ValidationResult results = productvalid.Validate(p);

            if (results.IsValid)
            {
                pm.ProductUpdate(p);
                TempData["protoastr"] = "Added";
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    TempData["protoastr"] = "Error";
                }
            }
            
            return RedirectToAction("Index", "Product");
        }
    }
}