using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.BusinessLayer.Abstract;
using Traversal.DTOLayer.DTOs.AnnouncementDTOs;
using Traversal.EntityLayer.Concrete;
using Traversal.PresentationLayer.Areas.Admin.Models;

namespace Traversal.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    [AllowAnonymous]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementServiceBL _announcementServiceBL;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementServiceBL announcementServiceBL, IMapper mapper)
        {
            _announcementServiceBL = announcementServiceBL;
            _mapper = mapper;
        }

        // Auto Mapper paketini kurmak için Presentation katmanına AutoMapper.Extensions.Microsoft.DependencyInjection paketini kuruyoruz.

        // Presentation katmanına Mapping adında yeni bir klasör oluşturuyoruz.

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementServiceBL.TGetList());
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementServiceBL.TInsert(new Announcement()
                {
                    AnnouncementContent = model.AnnouncementContent,
                    AnnouncementTitle = model.AnnouncementTitle,
                    AnnouncementDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });

                return RedirectToAction("Index", "Announcement", new { area = "Admin" });
            }
            return View(model);
        }

        public IActionResult DeleteAnnouncement(int id)
        {
            var values = _announcementServiceBL.TGetByID(id);
            _announcementServiceBL.TDelete(values);
            return RedirectToAction("Index", "Announcement", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {
            var values = _mapper.Map<AnnouncementEditDTO>(_announcementServiceBL.TGetByID(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAnnouncement(AnnouncementEditDTO model)
        {
            if (ModelState.IsValid)
            {
                _announcementServiceBL.TUpdate(new Announcement
                {
                    AnnouncementID = model.AnnouncementID,
                    AnnouncementTitle = model.AnnouncementTitle,
                    AnnouncementContent = model.AnnouncementContent,
                    AnnouncementDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index", "Announcement", new { area = "Admin" });
            }
            return View(model);
        }
    }
}
