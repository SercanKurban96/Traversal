using AutoMapper;
using Traversal.DTOLayer.DTOs.AnnouncementDTOs;
using Traversal.DTOLayer.DTOs.AppUserDTOs;
using Traversal.DTOLayer.DTOs.ContactDTOs;
using Traversal.EntityLayer.Concrete;

namespace Traversal.PresentationLayer.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            // Buradaki işlemleri yaptıktan sonra Program.cs sınıfına geliyoruz.

            // 1. Yol
            //CreateMap<AnnouncementAddDTOs, Announcement>();
            //CreateMap<Announcement, AnnouncementAddDTOs>();

            // 2. Yol
            CreateMap<AnnouncementAddDTO, Announcement>().ReverseMap();

            CreateMap<AppUserRegisterDTOs, AppUser>().ReverseMap();

            CreateMap<AppUserLoginDTOs, AppUser>().ReverseMap();

            CreateMap<AnnouncementListDTO, Announcement>().ReverseMap();

            CreateMap<AnnouncementEditDTO, Announcement>().ReverseMap();

            CreateMap<SendMessageDTO, ContactUs>().ReverseMap();
        }
    }
}
