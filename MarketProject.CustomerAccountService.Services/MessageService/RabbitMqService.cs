using MarketProject.CustomerAccountService.Services.MessageService.Interfaces;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketProject.CustomerAccountService.Services.MessageService
{
    public class RabbitMqService : IMessageService
    {
        private readonly ILogger<IMessageService> _logger;
        private readonly bool IsEnabled = true;

        public RabbitMqService(ILogger<IMessageService> logger)
        {
            _logger = logger;
        }

        public void Consume(string queueName)
        {
            _logger.LogInformation($"Consuming messages from queue [{queueName}] ...");

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            while (IsEnabled)
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += new EventHandler<BasicDeliverEventArgs>(OnReceived);

                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
            }
        }

        private void OnReceived(object? sender, BasicDeliverEventArgs args)
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine(" [x] Received:\n\t{0}", message);
        }
    }
}
