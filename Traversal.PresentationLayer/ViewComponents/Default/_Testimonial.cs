using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccessLayer.EntityFramework;

namespace Traversal.PresentationLayer.ViewComponents.Default
{
    public class _Testimonial : ViewComponent
    {
        TestimonialManagerBL tm = new TestimonialManagerBL(new EfTestimonialDAL());
        public IViewComponentResult Invoke()
        {
            var values = tm.TGetList();
            return View(values);
        }
    }
}
