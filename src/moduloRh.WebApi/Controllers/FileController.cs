using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using moduloRh.Application.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace moduloRh.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("[action]")]
        public IActionResult Upload([Required] List<IFormFile> files, [Required] Guid userId)
        {
            try
            {
                _fileService.UploadFile(files, userId);
                return Ok($"{files.Count} arquios Salvos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]")]
        public IActionResult Download([FromQuery] Guid userId)
        {
            try
            {
                var (fileType, archiveData, archiveName) = _fileService.DownloadFiles(userId);

                return File(archiveData, fileType, archiveName);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult Delete(Guid userId)
        {
            try
            {
                _fileService.DeletFile(userId);

                return Ok("Arquivos apagados");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
