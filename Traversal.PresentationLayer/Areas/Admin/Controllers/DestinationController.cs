using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.Concrete;
using Traversal.DataAccessLayer.EntityFramework;
using Traversal.EntityLayer.Concrete;

namespace Traversal.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DestinationController : Controller
    {
        private readonly IDestinationServiceBL _destinationServiceBL;

        public DestinationController(IDestinationServiceBL destinationServiceBL)
        {
            _destinationServiceBL = destinationServiceBL;
        }

        public IActionResult Index()
        {
            var values = _destinationServiceBL.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            _destinationServiceBL.TInsert(destination);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var values = _destinationServiceBL.TGetByID(id);
            _destinationServiceBL.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditDestination(int id)
        {
            var values = _destinationServiceBL.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditDestination(Destination destination)
        {
            _destinationServiceBL.TUpdate(destination);
            return RedirectToAction("Index");
        }
    }
}
