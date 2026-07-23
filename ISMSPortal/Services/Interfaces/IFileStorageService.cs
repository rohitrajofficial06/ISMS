using ISMSPortal.Helpers;
using Microsoft.AspNetCore.Http;

namespace ISMSPortal.Services.Interfaces
{
    public interface IFileStorageService
    {
        Task<FileUploadResult> UploadAsync(
            IFormFile file,
            string folderName);

        void DeleteFile(string? relativePath);
    }
}