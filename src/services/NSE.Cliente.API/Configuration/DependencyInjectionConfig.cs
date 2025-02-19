using NSE.Clientes.API.Data;
using NSE.Clientes.API.Data.Repository;
using NSE.Clientes.API.Models;
using NSE.Core.Mediator;

namespace NSE.Clientes.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Por meio de DI do MediatR ele encontra os commands e handler via reflefction e ele mesmo os registra, isso se os objetos
        /// estiverem no mesmo projeto ondce a DI é realizada. Caso contrário você precisa registrar.
        /// </summary>
        /// <param name="services"></param>
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Registra que o RegistrarClienteCommand será entregue via IRequestHandler e que vai retornar um ValidationResult será manipulado pelo ClienteCommandHandler, isso via MediaTr
            //services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
            //services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClientesContext>();
        }
    }
}
