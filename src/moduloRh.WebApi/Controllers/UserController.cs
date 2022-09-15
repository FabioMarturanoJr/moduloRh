using Microsoft.AspNetCore.Mvc;
using moduloRh.Application.Interfaces;
using moduloRh.Domain.Dto;
using System.ComponentModel.DataAnnotations;

namespace moduloRh.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ObjectResult Listar()
        {
            return Ok(_userService.ListarUsuarios());
        }

        [HttpPost]
        public ObjectResult Criar([FromBody][Required] UserCreateDto user)
        {
            _userService.Criar(user);
            return Ok(user);
        }

        [HttpDelete("{userId}")]
        public ObjectResult Deletar([Required] Guid userId)
        {
            _userService.Deletar(userId);
            return Ok(userId);
        }
    }
}