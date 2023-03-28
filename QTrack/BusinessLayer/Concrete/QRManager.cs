using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class QRManager:IQRService
    {
        IQRDal _QRdal;

        public QRManager(IQRDal QRdal)
        {
            _QRdal = QRdal;
        }

        public QR GetById(int id)
        {
            return _QRdal.Get(x => x.QRID == id);
        }

        public List<QR> GetList()
        {
            return _QRdal.List();
        }

        public List<QR> GetListById(int id)
        {
            return _QRdal.List(x => x.QRID == id);
        }

        public void QRAdd(QR qr)
        {
            _QRdal.Insert(qr);
        }

        public void QRDelete(QR qr)
        {
            _QRdal.Delete(qr);
        }

        public void QRUpdate(QR qr)
        {
            _QRdal.Update(qr);
        
        }
      
    }
}
