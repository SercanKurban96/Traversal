using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.DTOLayer.DTOs.AnnouncementDTOs;
using Traversal.EntityLayer.Concrete;

namespace Traversal.BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.AnnouncementTitle).NotEmpty().WithMessage("Lütfen başlığı boş geçmeyin");
            RuleFor(x => x.AnnouncementContent).NotEmpty().WithMessage("Lütfen duyuru içeriğini boş geçmeyin");
            RuleFor(x => x.AnnouncementTitle).MinimumLength(5).WithMessage("Lütfen en az 5 karakter girişi yapın.");
            RuleFor(x => x.AnnouncementContent).MinimumLength(20).WithMessage("Lütfen en az 20 karakter girişi yapın.");
            RuleFor(x => x.AnnouncementTitle).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapın.");
            RuleFor(x => x.AnnouncementContent).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakter girişi yapın.");
        }
    }
}
