using Microsoft.AspNetCore.Http;

namespace Demo.BLL.Services.AttachmentService
{
    public interface IAttachmentService
    {
        public string? Upload(IFormFile file,string folderName);
        public bool Delete(string filePath);
    }
}
