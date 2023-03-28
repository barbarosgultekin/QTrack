using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IQRHistoryService
    {
        List<QRHistory> GetList();
        List<QRHistory> GetListById(int id);
        void QRHistoryAdd(QRHistory QRHistory);
        void QRHistoryDelete(QRHistory QRHistory);
        void QRHistoryUpdate(QRHistory QRHistory);
        QRHistory GetById(int id);
    }
}
