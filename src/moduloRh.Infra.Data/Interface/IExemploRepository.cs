using moduloRh.Domain.Model;

namespace moduloRh.Infra.Data.Interface
{
    public interface IExemploRepository
    {
        List<UserModel> ListarUsuarios();
    }
}
