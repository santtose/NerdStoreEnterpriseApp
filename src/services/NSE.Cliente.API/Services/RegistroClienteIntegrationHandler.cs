﻿using EasyNetQ;
using FluentValidation.Results;
using NSE.Clientes.API.Application.Commands;
using NSE.Core.Mediator;
using NSE.Core.Messages.Integration;
using NSE.MessageBus;

namespace NSE.Clientes.API.Services
{
    // Manipula a integração trabalha como um background service
    public class RegistroClienteIntegrationHandler : BackgroundService
    {
        private IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public RegistroClienteIntegrationHandler(IServiceProvider serviceProvider, IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }

        // Para funcionar a tentativa de reconexão implementada no MessageBus. Nos últimos .NET não ha mais a necessidade
        //private void SetResponder()
        //{
        //    _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(async request =>
        //        await RegistrarCliente(request));

        //    _bus.AdvancedBus.Connected += OnConnect;
        //}

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _bus.RespondAsync<UsuarioRegistradoIntegrationEvent, ResponseMessage>(RegistrarCliente);
            //Se for usar, tirar o codigo acima, pois estará no SetResponder()
            //SetResponder();
            await Task.CompletedTask;            
        }

        //private void OnConnect(object s, EventArgs e)
        //{
        //    SetResponder();
        //}

        private async Task<ResponseMessage> RegistrarCliente(UsuarioRegistradoIntegrationEvent message)
        {
            var clienteCommand = new RegistrarClienteCommand(message.Id, message.Nome, message.Email, message.Cpf);
            ValidationResult sucesso;            

            // Por ser Singleton, precisa trabalhar por scopo, pois o mediatR é resolvido com AddScoped
            using (var scope = _serviceProvider.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediatorHandler>();
                sucesso = await mediator.EnviarComando(clienteCommand);
            }

            return new ResponseMessage(sucesso);
        }
    }
}
