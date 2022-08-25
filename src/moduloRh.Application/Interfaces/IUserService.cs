using moduloRh.Domain.Dto;

namespace moduloRh.Application.Interfaces
{
    public interface IUserService
    {
        List<UserDto> ListarUsuarios();
    }
}
