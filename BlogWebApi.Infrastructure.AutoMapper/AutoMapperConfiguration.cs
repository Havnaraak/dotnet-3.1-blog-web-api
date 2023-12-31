using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BlogWebApi.Infrastructure.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
