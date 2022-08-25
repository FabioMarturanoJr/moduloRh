using Microsoft.AspNetCore.Mvc;
using moduloRh.Application.Interfaces;

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

        [HttpGet("[action]")]
        public ObjectResult Listar()
        {
            return Ok(_exemploService.ListarUsuarios());
        }
    }
}