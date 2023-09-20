using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace PresentationLayer.Extensions
{
    public static class ServiceExtension
    {
        public static void MyconfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICarouselManager, CarouselManager>();
            services.AddScoped<ICarouselDal, CarouselDal>();

            services.AddScoped<IBrandManager, BrandManager>();
            services.AddScoped<IBrandDal, BrandDal>();


            services.AddScoped<IAboutManager, AboutManager>();
            services.AddScoped<IAboutDal, AboutDal>();

            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IServiceDal, ServiceDal>();


            services.AddScoped<ITeamManager, TeamManager>();
            services.AddScoped<ITeamDal, TeamDal>();


            services.AddScoped<ICarManager, CarManager>();
            services.AddScoped<ICarDal, CarDal>();


            services.AddScoped<ICarDetayManager, CarDetayManager>();
            services.AddScoped<ICarDetayDal, CarDetayDal>();

            services.AddScoped<ICarKategoriManager, CarKategoriManager>();
            services.AddScoped<ICarKategoriDal, CarKategoriDal>();


            services.AddScoped<IContactManager, ContactManager>();
            services.AddScoped<IContactDal, ContactDal>();

            services.AddScoped<IContactCityManager, ContactCityManager>();
            services.AddScoped<IContactCityDal, ContactCityDal>();

            services.AddScoped<ICarRequestFormManager, CarRequestFormManager>();
            services.AddScoped<ICarRequestFormDal, CarRequestFormDal>();




        }
    }
}
