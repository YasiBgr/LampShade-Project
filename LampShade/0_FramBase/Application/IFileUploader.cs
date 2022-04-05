using Microsoft.AspNetCore.Http;

namespace _0_FramBase.Application
{
    public interface IFileUploader
    {
        string Upload(IFormFile file,string path);
    }
}
