using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccessLayer.Concrete;
using Traversal.DataAccessLayer.EntityFramework;

namespace Traversal.PresentationLayer.ViewComponents.Default
{
    public class _Feature : ViewComponent
    {
        FeatureManagerBL fm = new FeatureManagerBL(new EfFeatureDAL());
        public IViewComponentResult Invoke()
        {
            //var values = fm.TGetList();

            return View();
        }
    }
}
