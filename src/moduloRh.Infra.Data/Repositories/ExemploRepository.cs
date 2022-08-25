using moduloRh.Domain.Model;
using moduloRh.Infra.Data.Context;
using moduloRh.Infra.Data.Interface;

namespace moduloRh.Infra.Data.Repositories
{
    public class ExemploRepository : IExemploRepository
    {
        private readonly RhContext _context;

        public ExemploRepository(RhContext context)
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
