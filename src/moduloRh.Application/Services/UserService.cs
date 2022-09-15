using AutoMapper;
using moduloRh.Application.Interfaces;
using moduloRh.Domain.Dto;
using moduloRh.Infra.Data.Interface;

namespace moduloRh.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void Criar(UserCreateDto user)
        {
            var userDb = _userRepository.GetByEmail(user.Email);

            if (userDb is not null)
                throw new Exception("Usuario Ja cadastrado");

            _userRepository.Criar(user);
        }

        public List<UserListDto> ListarUsuarios()
        {
            var usuarios = _userRepository.ListarUsuarios();
            return _mapper.Map<List<UserListDto>>(usuarios);
        }
    }
}
