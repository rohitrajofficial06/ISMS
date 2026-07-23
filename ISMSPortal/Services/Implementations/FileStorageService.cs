using ISMSPortal.Helpers;
using ISMSPortal.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace ISMSPortal.Services.Implementations
{
    public class FileStorageService : IFileStorageService
    {
        private readonly IWebHostEnvironment _environment;

        public FileStorageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<FileUploadResult> UploadAsync(
            IFormFile file,
            string folderName)
        {
            if (file == null || file.Length == 0)
                throw new Exception("Please select a file.");

            var allowedExtensions = new[]
            {
                ".pdf",
                ".doc",
                ".docx",
                ".xls",
                ".xlsx",
                ".ppt",
                ".pptx",
                ".jpg",
                ".jpeg",
                ".png"
            };

            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                throw new Exception("Invalid file type.");

            if (file.Length > 10 * 1024 * 1024)
                throw new Exception("Maximum file size is 10 MB.");

            var uploadFolder = Path.Combine(
                _environment.WebRootPath,
                "uploads",
                folderName);

            if (!Directory.Exists(uploadFolder))
                Directory.CreateDirectory(uploadFolder);

            var uniqueFileName =
                Guid.NewGuid().ToString() + extension;

            var fullPath =
                Path.Combine(uploadFolder, uniqueFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return new FileUploadResult
            {
                FileName = file.FileName,
                FilePath = $"/uploads/{folderName}/{uniqueFileName}",
                ContentType = file.ContentType
            };
        }

        public void DeleteFile(string? relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return;

            var filePath = Path.Combine(
                _environment.WebRootPath,
                relativePath.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));

            if (File.Exists(filePath))
                File.Delete(filePath);
        }
    }
}