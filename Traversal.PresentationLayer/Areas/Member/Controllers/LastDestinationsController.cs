using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;

namespace Traversal.PresentationLayer.Areas.Member.Controllers
{
    [Area("Member")]
    public class LastDestinationsController : Controller
    {
        private readonly IDestinationServiceBL _destinationServiceBL;

        public LastDestinationsController(IDestinationServiceBL destinationServiceBL)
        {
            _destinationServiceBL = destinationServiceBL;
        }

        public IActionResult Index()
        {
            var values = _destinationServiceBL.TGetLast4Destinations();
            return View(values);
        }
    }
}
