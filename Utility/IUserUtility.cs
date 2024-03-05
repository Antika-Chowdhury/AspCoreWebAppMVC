using AspCoreWebAppMVC.Models;

namespace AspCoreWebAppMVC.Utility
{
    public interface IUserUtility
    {
        Task<User> ConverToBase64(IFormFile pdfFile);

        Task<User> CovertFromBase64();
    }
}
