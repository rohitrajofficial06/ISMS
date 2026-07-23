public static class FileHelper
{
    public static async Task<string?> UploadFileAsync(
        IWebHostEnvironment environment,
        IFormFile? file,
        string folderName)
    {
        if (file == null || file.Length == 0)
            return null;

        string folder = Path.Combine(
            environment.WebRootPath,
            "uploads",
            folderName);

        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        string fileName =
            $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

        string fullPath = Path.Combine(folder, fileName);

        using FileStream stream = new(fullPath, FileMode.Create);

        await file.CopyToAsync(stream);

        return $"/uploads/{folderName}/{fileName}";
    }

    public static void DeleteFile(
        IWebHostEnvironment environment,
        string? filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
            return;

        string fullPath = Path.Combine(
            environment.WebRootPath,
            filePath.TrimStart('/')
                    .Replace('/', Path.DirectorySeparatorChar));

        if (File.Exists(fullPath))
            File.Delete(fullPath);
    }
}