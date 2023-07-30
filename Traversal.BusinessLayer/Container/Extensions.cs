using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.Abstract.AbstractUoW;
using Traversal.BusinessLayer.Concrete;
using Traversal.BusinessLayer.Concrete.ConcreteUoW;
using Traversal.BusinessLayer.ValidationRules;
using Traversal.DataAccessLayer.Abstract;
using Traversal.DataAccessLayer.EntityFramework;
using Traversal.DataAccessLayer.UnitOfWork;
using Traversal.DTOLayer.DTOs.AnnouncementDTOs;

namespace Traversal.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            // Refactoring işlemlerinde new'leme bağımlılığından kurtarmak için
            services.AddScoped<ICommentServiceBL, CommentManagerBL>();
            services.AddScoped<ICommentDAL, EfCommentDAL>();

            services.AddScoped<IDestinationServiceBL, DestinationManagerBL>();
            services.AddScoped<IDestinationDAL, EfDestinationDAL>();

            services.AddScoped<IAppUserServiceBL, AppUserManagerBL>();
            services.AddScoped<IAppUserDAL, EfAppUserDAL>();

            services.AddScoped<IReservationServiceBL, ReservationManagerBL>();
            services.AddScoped<IReservationDAL, EfReservationDAL>();

            services.AddScoped<IGuideServiceBL, GuideManagerBL>();
            services.AddScoped<IGuideDAL, EfGuideDAL>();

            services.AddScoped<IExcelServiceBL, ExcelManagerBL>();

            services.AddScoped<IPdfServiceBL, PdfManagerBL>();

            services.AddScoped<IContactUsServiceBL, ContactUsManagerBL>();
            services.AddScoped<IContactUsDAL, EfContactUsDAL>();

            services.AddScoped<IAnnouncementServiceBL, AnnouncementManagerBL>();
            services.AddScoped<IAnnouncementDAL, EfAnnouncementDAL>();

            services.AddScoped<IAccountServiceBL, AccountManagerBL>();
            services.AddScoped<IAccountDAL, EfAccountDAL>();

            services.AddScoped<IUoWDAL, UoWDAL>();
        }

        public static void CustomerValidator(this IServiceCollection services)
        {
            services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementValidator>();
        } 
    }
}
