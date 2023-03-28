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
    public class QRHistoryManager : IQRHistoryService
    {
        IQRHistoryDal _qrhistorydal;

        public QRHistoryManager(IQRHistoryDal QRHistoryDal)
        {
            _qrhistorydal = QRHistoryDal;
        }

        public QRHistory GetById(int id)
        {
            return _qrhistorydal.Get(x => x.REFID == id);
        }

        public List<QRHistory> GetList()
        {
            return _qrhistorydal.List();
        }

        public List<QRHistory> GetListById(int id)
        {
            return _qrhistorydal.List(x => x.QRID == id);
        }

        public void QRHistoryAdd(QRHistory QRHistory)
        {
            _qrhistorydal.Insert(QRHistory);
        }

        public void QRHistoryDelete(QRHistory QRHistory)
        {
            _qrhistorydal.Delete(QRHistory);
        }

        public void QRHistoryUpdate(QRHistory QRHistory)
        {
            _qrhistorydal.Update(QRHistory);
        }
    }
}
