using Microsoft.AspNetCore.Mvc;

namespace Traversal.PresentationLayer.ViewComponents.MemberLayout
{
    public class _MemberLayoutHead : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
