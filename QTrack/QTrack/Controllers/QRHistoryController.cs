using BusinessLayer.Concrete;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QTrack.Controllers
{
    public class QRHistoryController : Controller
    {

        QRHistoryManager qm = new QRHistoryManager(new EfQRHistoryDal());
        QRManager QRm = new QRManager(new EfQRDal());

        
        public ActionResult Index(int id)
        {
            var QRHValue = qm.GetListById(id);

            return View(QRHValue);
        }
        [AllowAnonymous]
        public ActionResult UserIndex(int id)
        {
            var QRHvalue = qm.GetListById(id);
            var QRV = QRm.GetById(id);
            ViewBag.QR = QRV.QRCODE;
            return View(QRHvalue);
        }

        [HttpPost]
        public ActionResult AddQRHistory(QRHistory p)
        {
            qm.QRHistoryAdd(p);

            return RedirectToAction("Index", "QR");
        }

        public PartialViewResult QRHistoryPartial()
        {
            List<SelectListItem> historyvalue = (from x in QRm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.QRCODE.ToString(),
                                                     Value = x.QRID.ToString()

                                                 }).ToList();



            ViewBag.hiva = historyvalue;
            return PartialView();
        }
    }
}