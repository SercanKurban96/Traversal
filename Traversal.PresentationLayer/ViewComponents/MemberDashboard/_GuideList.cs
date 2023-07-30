using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccessLayer.EntityFramework;

namespace Traversal.PresentationLayer.ViewComponents.MemberDashboard
{
    public class _GuideList : ViewComponent
    {
        private readonly IGuideServiceBL _guideServiceBL;

        public _GuideList(IGuideServiceBL guideServiceBL)
        {
            _guideServiceBL = guideServiceBL;
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideServiceBL.TGetList();
            return View(values);
        }
    }
}
