using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;

namespace Traversal.PresentationLayer.ViewComponents.Destination
{
    public class _GuideDetails : ViewComponent
    {
        private readonly IGuideServiceBL _guideServiceBL;

        public _GuideDetails(IGuideServiceBL guideServiceBL)
        {
            _guideServiceBL = guideServiceBL;
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideServiceBL.TGetByID(1);
            return View(values);
        }
    }
}
