using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moduloRh.Application.Interfaces;
using moduloRh.Domain.Dto;

namespace moduloRh.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessagenController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagenController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        public async Task SendMessage(MessageDto message)
        {
            await _messageService.SendMessagem(message);
        }
    }
}
