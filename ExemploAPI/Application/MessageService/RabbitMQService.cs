using Application.Interfaces.MessageService;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Application.MessageService
{
    public class RabbitMQService : IRabbitMQService
    {        
        public ConnectionFactory GetConnectionFactory(string hostname, string username, string password)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = hostname,
                UserName = username,
                Password = password
            };
            return connectionFactory;
        }
        public IConnection CreateConnection(ConnectionFactory connectionFactory)
        {
            return connectionFactory.CreateConnection();
        }

        public QueueDeclareOk CreateQueue(string queueName, IConnection connection)
        {
            QueueDeclareOk queue;
            using (var channel = connection.CreateModel())
            {
                queue = channel.QueueDeclare(queueName, false, false, false, null);
            }
            return queue;
        }
  
        public void PublishMessage(string message, string queueName, IConnection connection)
        {
            using (var channel = connection.CreateModel())
            {
                channel.BasicPublish(string.Empty, queueName, null, Encoding.ASCII.GetBytes(message));
            }            
        }     
    }
}
