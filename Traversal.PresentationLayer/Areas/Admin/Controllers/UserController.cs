using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.EntityLayer.Concrete;

namespace Traversal.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class UserController : Controller
    {
        private readonly IAppUserServiceBL _appUserServiceBL;
        private readonly IReservationServiceBL _reservationServiceBL;
        public UserController(IAppUserServiceBL appUserServiceBL, IReservationServiceBL reservationServiceBL)
        {
            _appUserServiceBL = appUserServiceBL;
            _reservationServiceBL = reservationServiceBL;
        }

        public IActionResult Index()
        {
            var values = _appUserServiceBL.TGetList();
            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values = _appUserServiceBL.TGetByID(id);
            _appUserServiceBL.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserServiceBL.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditUser(AppUser appUser)
        {
            _appUserServiceBL.TUpdate(appUser);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            _appUserServiceBL.TGetList();
            return View();
        }

        public IActionResult ReservationUser(int id)
        {
            var values = _reservationServiceBL.GetListWithReservationByAccepted(id);
            return View(values);
        }
    }
}
