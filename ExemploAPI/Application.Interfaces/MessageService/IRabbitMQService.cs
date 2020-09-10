using RabbitMQ.Client;

namespace Application.Interfaces.MessageService
{
    public interface IRabbitMQService
    {
        ConnectionFactory GetConnectionFactory(string hostname, string username, string password);
        IConnection CreateConnection(ConnectionFactory connectionFactory);
        QueueDeclareOk CreateQueue(string queueName, IConnection connection);
        void PublishMessage(string message, string queueName, IConnection connection);

    }
}
