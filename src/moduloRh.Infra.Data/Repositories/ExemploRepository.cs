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

        public List<string> ListarTextos()
        {
            var usuarios = _context.User.ToList();

            var lista = new List<string> { "Texto1", "Texto1" };
            return lista;
        }
    }
}
