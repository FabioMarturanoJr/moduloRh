using MassTransit;
using moduloRh.Application.Interfaces;
using moduloRh.Domain.Dto;
using RabbitMQ.Client;
using System.Text;

namespace moduloRh.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IPublishEndpoint _publisher;

        public MessageService(IPublishEndpoint publisher)
        {
            _publisher = publisher;
        }

        public async Task SendMessagem(MessageDto message)
        {
            await _publisher.Publish(message);
        }
    }
}
