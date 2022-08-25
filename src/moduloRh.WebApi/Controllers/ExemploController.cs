using Microsoft.AspNetCore.Mvc;
using moduloRh.Application.Interfaces;

namespace moduloRh.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExemploController : ControllerBase
    {
        private readonly IExemploService _exemploService;

        public ExemploController(IExemploService exemploService)
        {
            _exemploService = exemploService;
        }

        [HttpGet("[action]")]
        public ObjectResult ListarTextos()
        {
            return Ok(_exemploService.ListarUsuarios());
        }
    }
}