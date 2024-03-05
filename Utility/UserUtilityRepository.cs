using AspCoreWebAppMVC.Models;
using AspCoreWebAppMVC.Repositories.Interfaces;

namespace AspCoreWebAppMVC.Utility
{
    public class UserUtilityRepository : IUserUtility
    {
        public async Task<User> ConverToBase64(IFormFile pdfFile)
        {
            var user = new User();
            if (pdfFile != null && pdfFile.Length > 0)
            {
                user.PdfFileName = pdfFile.FileName;

                using (var memoryStream = new MemoryStream())
                {
                    await pdfFile.CopyToAsync(memoryStream); // Await the CopyToAsync method
                    user.PdfBase64Data = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return user;
        }


        public Task<User> CovertFromBase64()
        {
            throw new NotImplementedException();
        }
    }
}
