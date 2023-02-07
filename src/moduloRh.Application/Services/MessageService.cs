using MassTransit;
using Microsoft.Extensions.Configuration;
using moduloRh.Application.Interfaces;
using moduloRh.Domain.Dto;
using RabbitMQ.Client;
using System.Text;

namespace moduloRh.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly ISendEndpointProvider _sender;
        private readonly IConfiguration _configuration;

        public MessageService(ISendEndpointProvider sender, IConfiguration configuration)
        {
            _sender = sender;
            _configuration = configuration;
        }

        public async Task SendMessagem(MessageDto message)
        {
            var queueName = _configuration.GetConnectionString("QueueRabbit");
            var queue = await _sender.GetSendEndpoint(new Uri("queue:" + queueName));
            await queue.Send(message);
        }
    }
}
