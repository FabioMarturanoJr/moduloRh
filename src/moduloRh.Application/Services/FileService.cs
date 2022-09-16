using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using moduloRh.Application.Interfaces;
using moduloRh.Infra.Data.Interface;
using System.IO.Compression;

namespace moduloRh.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IUserRepository _userRepository;

        public FileService(IHostingEnvironment hostingEnvironment, IUserRepository userRepository)
        {
            _hostingEnvironment = hostingEnvironment;
            _userRepository = userRepository;
        }

        public void UploadFile(List<IFormFile> files, Guid userId)
        {
            if (userId == Guid.Empty)
                throw new Exception("User Id Empty");

            if (files.Count <= 0)
                throw new Exception($"Count files = {files.Count}");

            if (_userRepository.GetByGuid(userId) == null)
                throw new Exception("User Not Found");

            var dirPath = Path.Combine(_hostingEnvironment.ContentRootPath, "Files", userId.ToString());

            var dir = Directory.CreateDirectory(dirPath);

            files.ForEach(async file =>
            {
                if (file.Length <= 0) return;
                await SaveFile(file, dirPath, dir);
            });
        }

        private static async Task SaveFile(IFormFile file, string target, DirectoryInfo dir)
        {
            var fileDir = dir.GetFiles(file.FileName);

            if (fileDir.Length > 0)
                File.Delete(fileDir.FirstOrDefault().FullName);

            var filePath = Path.Combine(target, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }

        public (string fileType, byte[] archiveData, string archiveName) DownloadFiles(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new Exception("User Id Empty");

            if (_userRepository.GetByGuid(userId) == null)
                throw new Exception("User Not Found");

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
        
        public void DeletFile(Guid userId)
        {
            var pathFiles = Path.Combine(_hostingEnvironment.ContentRootPath, "Files");

            var directory = new DirectoryInfo(pathFiles);

            foreach (var dir in directory.GetDirectories())
            {
                if (dir.Name == userId.ToString())
                {
                    dir.Delete(true);
                }
            }
        }
    }
}
