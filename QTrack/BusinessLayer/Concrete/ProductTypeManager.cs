using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProductTypeManager : IProductTypeService
    {
        IProductTypeDal _producttypedal;

        public ProductTypeManager(IProductTypeDal producttypedal)
        {
            _producttypedal = producttypedal;
        }

        public ProductType GetById(int id)
        {
            return _producttypedal.Get(x => x.PTYPEID == id);
        }

        public List<ProductType> GetList()
        {
            return _producttypedal.List();
        }

        public List<ProductType> GetListById(int id)
        {
            return _producttypedal.List(x => x.PTYPEID == id);
        }

        public void ProductTypeAdd(ProductType ProductType)
        {
            _producttypedal.Insert(ProductType);
        }

        public void ProductTypeDelete(ProductType ProductType)
        {
            _producttypedal.Delete(ProductType);
        }

        public void ProductTypeUpdate(ProductType ProductType)
        {
            _producttypedal.Update(ProductType);
        }
      
    }
}
