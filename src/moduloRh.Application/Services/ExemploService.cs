using AutoMapper;
using moduloRh.Application.Interfaces;
using moduloRh.Domain.Dto;
using moduloRh.Infra.Data.Interface;

namespace moduloRh.Application.Services
{
    public class ExemploService : IExemploService
    {
        private readonly IExemploRepository _exemploRepository;
        private readonly IMapper _mapper;

        public ExemploService(IExemploRepository exemploRepository, IMapper mapper)
        {
            _exemploRepository = exemploRepository;
            _mapper = mapper;
        }

        public List<UserDto> ListarUsuarios()
        {
            var usuarios = _exemploRepository.ListarUsuarios();
            return _mapper.Map<List<UserDto>>(usuarios);
        }
    }
}
