using FluentValidation.Results;
using MediatR;

namespace NSE.Core.Messages
{
    // IRequest (Mediatr) é interface de marcacao que significa que esse command é um tipo de request a ser entregue
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        // Saber o momento em que o comando gerou os resultados, por questões de mapeamento
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
