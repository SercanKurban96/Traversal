using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Concrete;

namespace Traversal.BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x=>x.AboutDescription).NotEmpty().WithMessage("Açıklama kısmı boş bırakılamaz...");
            RuleFor(x=>x.AboutImage1).NotEmpty().WithMessage("Lütfen görsel seçiniz...");
            RuleFor(x=>x.AboutDescription).MinimumLength(10).WithMessage("Lütfen en az 10 karakterlik açıklama bilgisi girin...");
            RuleFor(x=>x.AboutDescription).MaximumLength(1000).WithMessage("Lütfen en fazla 1000 karakterlik açıklama bilgisi girin...");
        }
    }
}
