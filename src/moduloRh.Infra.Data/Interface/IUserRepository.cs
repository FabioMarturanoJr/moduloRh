using moduloRh.Domain.Model;

namespace moduloRh.Infra.Data.Interface
{
    public interface IUserRepository
    {
        List<UserModel> ListarUsuarios();
    }
}
