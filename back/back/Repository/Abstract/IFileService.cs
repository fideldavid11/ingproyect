using Microsoft.AspNetCore.Http;

namespace back.Repository.Abstract
{
    public interface IFileService
    {
        Tuple<int, string> SaveImage(IFormFile imageFile);
        bool DeleteImage(string imageFileName);
    }
}
