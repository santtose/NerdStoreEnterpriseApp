using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependenceInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Registro do httpClient
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
        }
        
    }
}
