using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services.AttachmentService
{
    public class AttachmentService : IAttachmentService
    {
        List<string> allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png"};
        const int maxFileSize = 2 * 1024 * 1024; 

        public string? Upload(IFormFile file, string folderName)
        {
            var extension = Path.GetExtension(file.FileName);
            if (!allowedExtensions.Contains(extension.ToLower())) return null;
            if (file.Length > maxFileSize || file.Length == 0) return null;
            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "files", folderName);
            var uniqueFileName = Guid.NewGuid().ToString() + extension;
            var filePath = Path.Combine(folderPath, uniqueFileName);
            using FileStream stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);
            return uniqueFileName;
        }
        public bool Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            else
                return false;
        }
    }
}
