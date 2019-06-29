using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.Northwind.Business.ValidationRules.FluentValidation
{
    public class EkranValidator : AbstractValidator<Ekran>
    {
        public EkranValidator()
        {
            RuleFor(p => p.EkranUrl).NotEmpty().Length(0, 100);

            RuleFor(p => p.CihazId).NotNull();
            //.WithMessage("Açılış tarihi gereklidir.");
            
            RuleFor(p => p.KonumId).NotNull();
            RuleFor(p => p.MonitorId).NotNull();
            RuleFor(p => p.Aciklama).MaximumLength(100);
            //.LessThanOrEqualTo(0).WithMessage("Enlem en az 0 olabilir.");
            //.LessThanOrEqualTo(0).WithMessage("Boylam en az 0 olabilir.");
        }
    }
}