using SignalR.Business.Concrete;
using SignalR.Business.Interfaces;
using SignalR.DataAccess.Interfaces;
using SignalR.DataAccess.Repositories;

namespace SignalR.API.Extensions
{
    public static class ServiceDependencyInjections
    {

        public static void AddServiceDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IDiscountService, DiscountService>();
            services.AddScoped<IFeatureService, FeatureService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISocialMediaService, SocialMediaService>();
            services.AddScoped<ITestimonialService, TestimonialService>();
        }


    }
}
