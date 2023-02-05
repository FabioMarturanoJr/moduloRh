using moduloRh.Domain.Dto;

namespace moduloRh.Application.Interfaces
{
    public interface IMessageService
    {
        Task SendMessagem(MessageDto message);
    }
}
