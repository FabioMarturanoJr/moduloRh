using moduloRh.Domain.Dto;
using moduloRh.Domain.Model;

namespace moduloRh.Application.Interfaces
{
    public interface IUserService
    {
        List<UserListDto> ListarUsuarios();
        void Criar(UserCreateDto user);
    }
}
