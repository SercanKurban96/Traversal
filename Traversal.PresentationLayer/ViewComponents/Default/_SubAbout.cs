using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccessLayer.EntityFramework;

namespace Traversal.PresentationLayer.ViewComponents.Default
{
    public class _SubAbout : ViewComponent
    {
        SubAboutManagerBL sam = new SubAboutManagerBL(new EfSubAboutDAL());
        public IViewComponentResult Invoke()
        {
            var values = sam.TGetList();
            return View(values);
        }
    }
}
