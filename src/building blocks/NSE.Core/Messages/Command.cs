using FluentValidation.Results;

namespace NSE.Core.Messages
{
    public abstract class Command : Message
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
