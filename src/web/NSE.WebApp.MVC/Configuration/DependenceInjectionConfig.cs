using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using Polly;
using Polly.Extensions.Http;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependenceInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Cria uma nova instância sempre que o serviço for solicitado.
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            // Registro do httpClient
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();

            var retryWaitPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(new[]
                {
                    TimeSpan.FromSeconds(1),
                    TimeSpan.FromSeconds(2),
                    TimeSpan.FromSeconds(4),
                }, (outcome, timespan, retryCount, context) =>
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Tentando pela {retryCount} vez!");
                    Console.ForegroundColor = ConsoleColor.White;
                });

            services.AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                .AddPolicyHandler(retryWaitPolicy);

            // Cada request é uma representação unica. Uma única instância do serviço para toda a aplicação
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Base no request especifico. Cria uma única instância por requisição (scope).
            services.AddScoped<IUser, AspNetUser>();
        }
        
    }
}
