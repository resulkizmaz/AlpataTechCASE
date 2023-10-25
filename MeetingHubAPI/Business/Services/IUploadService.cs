using Microsoft.AspNetCore.Http;

namespace Business
{
    public interface IUploadService
    {
        Task<string> UploadSubscriberDocument(IFormFile file);
    }
}
