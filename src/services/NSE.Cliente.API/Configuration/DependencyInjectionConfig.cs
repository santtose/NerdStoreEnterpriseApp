using FluentValidation.Results;
using MediatR;
using NSE.Clientes.API.Application.Commands;
using NSE.Core.Mediator;

namespace NSE.Clientes.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            // Registra que o RegistrarClienteCommand será entregue via IRequestHandler e que vai retornar um ValidationResult será manipulado pelo ClienteCommandHandler, isso via MediaTr
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
        }
    }
}
