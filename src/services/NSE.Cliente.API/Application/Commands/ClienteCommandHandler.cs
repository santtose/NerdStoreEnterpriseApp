using FluentValidation.Results;
using MediatR;
using NSE.Clientes.API.Models;
using NSE.Core.Messages;

namespace NSE.Clientes.API.Application.Commands
{
    // Manipulador do comando de transporte (RegistrarClienteCommand).
    // IRequestHandler - Manipulador do request
    public class ClienteCommandHandler : CommandHandler, IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var cliente = new Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            if (true)
            {
                AdicionarErro("Este CPF já está em uso.");
                return ValidationResult;
            }

            return message.ValidationResult;
        }
    }
}
