using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal.BusinessLayer.Abstract;
using Traversal.EntityLayer.Concrete;
using Traversal.PresentationLayer.Models;

namespace Traversal.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationServiceBL _destinationServiceBL;

        public CityController(IDestinationServiceBL destinationServiceBL)
        {
            _destinationServiceBL = destinationServiceBL;
        }

        public IActionResult Index()
        {
            return View();
        }

        // Listeleme işlemi
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationServiceBL.TGetList());
            return Json(jsonCity);
        }

        // Ekleme işlemi
        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            destination.Status = true;
            _destinationServiceBL.TInsert(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        // ID getirme işlemi
        public IActionResult GetByID(int DestinationID)
        {
            var values = _destinationServiceBL.TGetByID(DestinationID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        // Silme işlemi
        public IActionResult DeleteCity(int id)
        {
            var values = _destinationServiceBL.TGetByID(id);
            _destinationServiceBL.TDelete(values);
            return NoContent();
        }

        // Güncelleme işlemi
        public IActionResult UpdateCity(Destination destination)
        {
            var values = _destinationServiceBL.TGetByID(destination.DestinationID);
            destination.Status = values.Status;
            destination.Price = values.Price;
            destination.ImageUrl = values.ImageUrl;
            destination.Description = values.Description;
            destination.Capacity = values.Capacity;
            destination.CoverImage = values.CoverImage;
            destination.Details1 = values.Details1;
            destination.Details2 = values.Details2;
            destination.ImageUrl2 = values.ImageUrl2;
            _destinationServiceBL.TUpdate(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }


        // Statik İşlemler
        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID = 1,
        //        CityName = "Üsküp",
        //        CityCountry = "Makedonya"
        //    },
        //    new CityClass
        //    {
        //        CityID = 2,
        //        CityName = "Roma",
        //        CityCountry = "İtalya"
        //    },
        //    new CityClass
        //    {
        //        CityID = 3,
        //        CityName = "Londra",
        //        CityCountry = "İngiltere"
        //    }
        //};   
    }
}
