using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;

namespace Traversal.PresentationLayer.ViewComponents.MemberDashboard
{
    public class _LastDestinations : ViewComponent
    {
        private readonly IDestinationServiceBL _destinationServiceBL;

        public _LastDestinations(IDestinationServiceBL destinationServiceBL)
        {
            _destinationServiceBL = destinationServiceBL;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationServiceBL.TGetLast4Destinations();
            return View(values);
        }
    }
}
