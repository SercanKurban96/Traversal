using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.EntityLayer.Concrete;

namespace Traversal.BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen rehber adını giriniz.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen rehber açıklamasını giriniz.");
            RuleFor(x => x.GuideImage).NotEmpty().WithMessage("Lütfen rehber görselini giriniz.");
            RuleFor(x => x.Name).MaximumLength(60).WithMessage("Lütfen 60 karakterden daha kısa bir isim giriniz.");
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen 5 karakterden daha uzun bir isim giriniz.");
        }
    }
}
