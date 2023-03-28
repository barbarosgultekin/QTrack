using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class QRValidator: AbstractValidator<QR>
    {
        public QRValidator()
        {
            RuleFor(x => x.QRCODE).NotEmpty().WithMessage("QR Not Empty");
        }
    }
}
