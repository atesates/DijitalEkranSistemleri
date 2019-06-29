using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.Northwind.Business.ValidationRules.FluentValidation
{
    public class KonumValidator : AbstractValidator<Konum>
    {
        public KonumValidator()
        {
            RuleFor(p => p.Aciklama).NotEmpty().Length(0, 100);

            RuleFor(p => p.Enlem).NotNull();
            RuleFor(p => p.Boylam).NotNull();
            // RuleFor(p => p.Url).NotNull();
            //.WithMessage("Açılış tarihi gereklidir.");
            //.LessThanOrEqualTo(0).WithMessage("Enlem en az 0 olabilir.");
            //.LessThanOrEqualTo(0).WithMessage("Boylam en az 0 olabilir.");
        }
    }
}