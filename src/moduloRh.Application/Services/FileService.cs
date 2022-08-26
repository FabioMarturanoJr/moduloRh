using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using moduloRh.Application.Interfaces;
using System.IO.Compression;

namespace moduloRh.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileService(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public void UploadFile(List<IFormFile> files, Guid userId)
        {
            if (userId == Guid.Empty)
                throw new Exception("User Id Empty");

            if (files.Count <= 0)
                throw new Exception($"Count files = {files.Count}");

            var target = Path.Combine(_hostingEnvironment.ContentRootPath, "Files", userId.ToString());

            Directory.CreateDirectory(target);

            files.ForEach(async file =>
            {
                if (file.Length <= 0) return;
                var filePath = Path.Combine(target, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            });
        }

        public (string fileType, byte[] archiveData, string archiveName) DownloadFiles(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new Exception("User Id Empty");

            var zipName = $"archive-{DateTime.Now.ToString("dd_MM_yyyy-HH_mm_ss")}.zip";

            var files = Directory.GetFiles(Path.Combine(_hostingEnvironment.ContentRootPath, "Files", userId.ToString())).ToList();

            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ForEach(file =>
                    {
                        archive.CreateEntryFromFile(file, Path.GetFileName(file));
                    });
                }

                return ("application/zip", memoryStream.ToArray(), zipName);
            }
        }
        

        public string SizeConverter(long bytes)
        {
            throw new NotImplementedException();
        }

    }
}
