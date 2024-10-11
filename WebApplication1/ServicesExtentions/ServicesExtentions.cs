using WebApplication1.Interfaces.FacultyInterfaces;

namespace WebApplication1.ServicesExtentions
{
    public static class ServicesExtentions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IFacultyServices, FacultyServices>();
            return services;
        }
    }
}
