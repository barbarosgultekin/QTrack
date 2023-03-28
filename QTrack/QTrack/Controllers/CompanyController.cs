
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace QTrack.Controllers
{
    public class CompanyController : Controller
    {
        CompanyManager cm = new CompanyManager(new EfCompanyDal());

        //private ICompanyService _icompanyService;

        //public CompanyController(ICompanyService icompanyService)
        //{
        //    this._icompanyService = icompanyService;
        //}

        public ActionResult Index()
        {
            var companyvalue = cm.GetList();
            return View(companyvalue);

        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddCompany(Company company)
        {
            var result = cm.CompanyAdd(company);

            if (result)
            {
                TempData["message"] = "Kayıt Başarılı";
                TempData["msg"] = "Added";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "Giriş Dizesi Uygun Değil";
                TempData["msg"] = "Error";

            }
            return RedirectToAction("Index");
        }

        public PartialViewResult CompanyPartial()
        {
            return PartialView();
        }

        //[Authorize(Roles = "Admin")]

        [HttpGet]
        public ActionResult EditCompany(int id)
        {
            List<SelectListItem> valuecompany = (from x in cm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CNAME,
                                                     Value = x.COMPANYID.ToString()

                                                 }).ToList();
            ViewBag.cv = valuecompany;

            var companyvalue = cm.GetById(id);
            return View(companyvalue);

        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditCompany(Company p)
        {
            CompanyValidator companyvalid = new CompanyValidator();
            //ValidationResult results = companyvalid.Validate(p);


            cm.CompanyUpdate(p);
            return RedirectToAction("Index");

            //foreach (var item in results.Errors)
            //{
            //    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //}

            return RedirectToAction("Index", "Company");
        }
        //[Authorize(Roles = "Admin")]
        public ActionResult DeleteCompany(Company company)
        {
            cm.CompanyDelete(company);
            return RedirectToAction("Index");
        }

    }
}