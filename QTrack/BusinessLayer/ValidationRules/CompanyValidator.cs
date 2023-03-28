using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CompanyValidator:AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(x => x.CNAME).NotEmpty().WithMessage("Company Name Not Empty");
            RuleFor(x => x.CPHONE).Length(10);          
        }
    }
}
