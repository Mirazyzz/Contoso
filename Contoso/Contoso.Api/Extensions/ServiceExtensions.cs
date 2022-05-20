using Contoso.Domain.Interfaces.Repostiory;
using Contoso.Domain.Interfaces.Services;
using Contoso.Repositories;
using Contoso.Services;

namespace Contoso.Api.Extensions
{
    public static class ServiceExtensions
    {
        #region Configure Dependency Injection

        public static void RegisterDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICommonRepository, CommonRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICityService, CityService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        #endregion
    }
}
