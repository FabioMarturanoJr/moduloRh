using AutoMapper;
using moduloRh.Domain.Dto;
using moduloRh.Domain.Model;
using moduloRh.Infra.Data.Context;
using moduloRh.Infra.Data.Interface;

namespace moduloRh.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly RhContext _context;
        private readonly IMapper _mapper;

        public UserRepository(RhContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Criar(UserCreateDto user)
        {
            var userDb = _mapper.Map<UserModel>(user);
            _context.User.Add(userDb);
            _context.SaveChanges();
        }

        public void Deletar(UserModel user)
        {
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public UserModel GetByEmail(string email)
        {
            return _context.User
                .Where(u => u.Email.Equals(email)).FirstOrDefault();
        }

        public UserModel GetByGuid(Guid id)
        {
            return _context.User
                .Where(u => u.Id.Equals(id)).FirstOrDefault();
        }

        public UserModel Find(UserCreateDto user)
        {
            return _context.User
                .FirstOrDefault(u => u.Email == user.Email
                    && u.Password == user.Password);
        }

        public List<UserModel> ListarUsuarios()
        {
            var usuarios = _context.User.ToList();
            return usuarios;
        }
    }
}
