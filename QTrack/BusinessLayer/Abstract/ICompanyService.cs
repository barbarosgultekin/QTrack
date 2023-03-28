using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICompanyService
    {
        List<Company> GetList();
        List<Company> GetListById(int id);
        bool CompanyAdd(Company company);
        void CompanyDelete(Company company);
        void CompanyUpdate(Company company);
        Company GetById(int id);
    }
}
