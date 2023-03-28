using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IQRService
    {
        List<QR> GetList();
        List<QR> GetListById(int id);
        void QRAdd(QR QR);
        void QRDelete(QR QR);
        void QRUpdate(QR QR);
        QR GetById(int id);
    }
}
