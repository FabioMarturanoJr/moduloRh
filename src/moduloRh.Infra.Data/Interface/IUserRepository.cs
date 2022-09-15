using moduloRh.Domain.Dto;
using moduloRh.Domain.Model;

namespace moduloRh.Infra.Data.Interface
{
    public interface IUserRepository
    {
        List<UserModel> ListarUsuarios();
        UserModel GetByEmail(string email);
        UserModel GetByGuid(Guid id);
        void Criar(UserCreateDto user);
        void Deletar(UserModel user);
    }
}
