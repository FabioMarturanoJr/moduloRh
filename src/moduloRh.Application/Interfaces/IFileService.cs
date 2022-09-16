using Microsoft.AspNetCore.Http;

namespace moduloRh.Application.Interfaces
{
    public interface IFileService
    {
        void UploadFile(List<IFormFile> files, Guid userId);
        (string fileType, byte[] archiveData, string archiveName) DownloadFiles(Guid userId);
        void DeletFile(Guid userId);
    }
}
