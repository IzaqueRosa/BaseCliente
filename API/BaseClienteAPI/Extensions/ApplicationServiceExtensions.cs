using BaseCliente.Domain.Interfaces.Repositories;
using BaseCliente.Domain.Interfaces.Services;
using BaseCliente.Domain.Repositories;
using BaseCliente.Domain.Services;

namespace BaseClienteAPI.Extensions
{
    /// <summary>
    /// API configuration class
    /// </summary>
    public static class ApplicationServiceExtensions
    {
        /// <summary>
        /// Method responsible for injecting service dependencies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public static IServiceCollection AddServiceInjection(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IBancoService, BancoService>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
