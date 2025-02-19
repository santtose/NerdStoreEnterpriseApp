namespace NSE.Core.Messages
{
    // Classe base para os comandos
    public abstract class Message
    {        
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}
