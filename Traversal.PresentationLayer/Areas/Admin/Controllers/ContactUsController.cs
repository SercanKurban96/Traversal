using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;

namespace Traversal.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactUsController : Controller
    {
        private readonly IContactUsServiceBL _contactUsServiceBL;

        public ContactUsController(IContactUsServiceBL contactUsServiceBL)
        {
            _contactUsServiceBL = contactUsServiceBL;
        }

        public IActionResult Index()
        {
            var values = _contactUsServiceBL.TGetListContactUsByTrue();
            return View(values);
        }
    }
}
