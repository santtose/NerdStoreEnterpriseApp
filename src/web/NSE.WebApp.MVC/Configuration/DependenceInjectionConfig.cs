using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependenceInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Registro do httpClient
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            // Cada request é uma representação unica. Uma única instância do serviço para toda a aplicação
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpClient<ICatalogoService, CatalogoService>();

            // Base no request especifico. Uma instância por requisição HTTP
            services.AddScoped<IUser, AspNetUser>();
        }
        
    }
}
