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
    public class ProductManager:IProductService
    {
        IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public Product GetById(int id)
        {
            return _productdal.Get(x => x.PRODUCTID == id);
        }

        public List<Product> GetList()
        {
            return _productdal.List();
        }

        public List<Product> GetListById(int id)
        {
            return _productdal.List(x => x.PRODUCTID == id);
        }

        public void ProductAdd(Product product)
        {
            _productdal.Insert(product);
        }

        public void ProductDelete(Product product)
        {
            _productdal.Delete(product);
        }

        public void ProductUpdate(Product product)
        {
            _productdal.Update(product);
        }

    }
}
