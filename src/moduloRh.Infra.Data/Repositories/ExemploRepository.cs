using moduloRh.Infra.Data.Interface;

namespace moduloRh.Infra.Data.Repositories
{
    public class ExemploRepository : IExemploRepository
    {
        public List<string> ListarTextos()
        {
            var lista = new List<string> { "Texto1", "Texto1" };
            return lista;
        }
    }
}
