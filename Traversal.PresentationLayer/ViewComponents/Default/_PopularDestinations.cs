using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccessLayer.EntityFramework;

namespace Traversal.PresentationLayer.ViewComponents.Default
{
    public class _PopularDestinations : ViewComponent
    {
        DestinationManagerBL dm = new DestinationManagerBL(new EfDestinationDAL());
        public IViewComponentResult Invoke()
        {
            var values = dm.TGetList();
            return View(values);
        }
    }
}
