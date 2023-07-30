using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccessLayer.EntityFramework;

namespace Traversal.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        GuideManagerBL gm = new GuideManagerBL(new EfGuideDAL());
        public IActionResult Index()
        {
            var values = gm.TGetList();
            return View(values);
        }
    }
}
