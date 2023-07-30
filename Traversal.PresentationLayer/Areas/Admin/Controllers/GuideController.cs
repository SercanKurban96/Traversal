using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.ValidationRules;
using Traversal.EntityLayer.Concrete;

namespace Traversal.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideController : Controller
    {
        private readonly IGuideServiceBL _guideServiceBL;

        public GuideController(IGuideServiceBL guideServiceBL)
        {
            _guideServiceBL = guideServiceBL;
        }

        GuideValidator validationRules = new GuideValidator();

        public IActionResult Index()
        {
            var values = _guideServiceBL.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            ValidationResult result = validationRules.Validate(guide);

            if (result.IsValid)
            {
                _guideServiceBL.TInsert(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideServiceBL.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditGuide(Guide guide)
        {
            ValidationResult result = validationRules.Validate(guide);

            if (result.IsValid)
            {
                _guideServiceBL.TUpdate(guide);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        public IActionResult ChangeToTrue(int id)
        {
            _guideServiceBL.TChangeToTrueByGuide(id);
            return RedirectToAction("Index", "Guide", new {area = "Admin"});
        }

        public IActionResult ChangeToFalse(int id)
        {
            _guideServiceBL.TChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
    }
}
