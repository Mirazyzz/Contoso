using Contoso.Domain.Interfaces.Services;
using Contoso.Services;

namespace Contoso.Api.Extensions
{
    public static class ServiceExtensions
    {
        #region Configure Dependency Injection

        public static void RegisterDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
        }

        #endregion
    }
}
