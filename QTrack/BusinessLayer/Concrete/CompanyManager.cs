using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntitiyFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CompanyManager : ICompanyService
    {
        //ICompanyDal _companydal;
        //CompanyValidator _companyvalid;
        //private EfCompanyDal efCompanyDal;

        //public CompanyManager(EfCompanyDal efCompanyDal)
        //{
        //    this.efCompanyDal = efCompanyDal;
        //}

        //public CompanyManager(ICompanyDal companydal, CompanyValidator companyvalid)
        //{
        //    _companydal = companydal;
        //    _companyvalid = companyvalid;
        //}


        ICompanyDal _companydal;


        public CompanyManager(ICompanyDal companydal)
        {
            _companydal = companydal;
        }

        public bool CompanyAdd(Company company)
        {
            _companydal.Insert(company);
            return true;

        }

        public void CompanyDelete(Company company)
        {
            var model = GetById(company.COMPANYID);
            model.CSTATUS = false;
            _companydal.Update(model);
        }

        public void CompanyUpdate(Company company)
        {
            _companydal.Update(company);
        }

        public Company GetById(int id)
        {
            return _companydal.Get(x => x.COMPANYID == id);
        }

        public List<Company> GetList()
        {
            return _companydal.List();
        }

        public List<Company> GetListById(int id)
        {
            return _companydal.List(x => x.COMPANYID == id);
        }
    }
}
