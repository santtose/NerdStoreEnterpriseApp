using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependenceInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Cria uma nova instância sempre que o serviço for solicitado.
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            // Registro do httpClient
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();              

            // Cada request é uma representação unica. Uma única instância do serviço para toda a aplicação
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddHttpClient<ICatalogoService, CatalogoService>()
            //    .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>();

            // refit
            services.AddHttpClient("Refit", 
                options =>
                {
                    options.BaseAddress = new Uri(configuration.GetSection("CatalogoUrl").Value);
                })
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);

            // Base no request especifico. Cria uma única instância por requisição (scope).
            services.AddScoped<IUser, AspNetUser>();
        }
        
    }
}
