using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IProductTypeService
    {
        List<ProductType> GetList();
        List<ProductType> GetListById(int id);
        void ProductTypeAdd(ProductType ProductType);
        void ProductTypeDelete(ProductType ProductType);
        void ProductTypeUpdate(ProductType ProductType);
        ProductType GetById(int id);
    }
}
