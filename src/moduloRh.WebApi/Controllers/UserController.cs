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
        private readonly IUserService _exemploService;

        public UserController(IUserService exemploService)
        {
            _exemploService = exemploService;
        }

        [HttpGet]
        public ObjectResult Listar()
        {
            return Ok(_exemploService.ListarUsuarios());
        }

        [HttpPost]
        public ObjectResult Criar([FromBody][Required] UserCreateDto user)
        {
            _exemploService.Criar(user);
            return Ok(user);
        }
    }
}