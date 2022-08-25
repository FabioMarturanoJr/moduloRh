using moduloRh.Domain.Model;
using moduloRh.Infra.Data.Context;
using moduloRh.Infra.Data.Interface;

namespace moduloRh.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RhContext _context;

        public UserRepository(RhContext context)
        {
            _context = context;
        }

        public List<UserModel> ListarUsuarios()
        {
            var usuarios = _context.User.ToList();

            return usuarios;
        }
    }
}
