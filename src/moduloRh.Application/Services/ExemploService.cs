using moduloRh.Application.Interfaces;
using moduloRh.Infra.Data.Interface;

namespace moduloRh.Application.Services
{
    public class ExemploService : IExemploService
    {
        private readonly IExemploRepository _exemploRepository;

        public ExemploService(IExemploRepository exemploRepository)
        {
            _exemploRepository = exemploRepository;
        }

        public List<string> ListarTextos()
        {
            return _exemploRepository.ListarTextos();
        }
    }
}
