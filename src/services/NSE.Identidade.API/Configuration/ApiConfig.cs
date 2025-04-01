using NSE.WebAPI.Core.Usuario;

namespace NSE.Identidade.API.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfiguration(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<IAspNetUser, AspNetUser>();

            return services;
        }
    }
}
