using AspCoreWebAppMVC.Data;
using AspCoreWebAppMVC.Models;
using AspCoreWebAppMVC.Repositories.Interfaces;
using AspCoreWebAppMVC.Utility;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace AspCoreWebAppMVC.Repositories.Implementation
{
    public class UserRepository : IUser
    {
        private readonly ApplicationContext context;
        private IUserUtility userUtility;

        public UserRepository(ApplicationContext context, IUserUtility utility)
        {
            this.context = context;
            this.userUtility = utility;
        }


        public async Task<int> CreateUser(User user)
        {

           var newuser = await userUtility.ConverToBase64(user.PdfFile);
            newuser.Name = user.Name;
            newuser.Address = user.Address;
            newuser.PhoneNumber = user.PhoneNumber;
            context.User.Add(newuser);
            await context.SaveChangesAsync();
            return user.Id;
        }


        public Task DeleteUser(int id)
        {
            return Task.FromResult(0);
        }

        public void Dispose()
        {
            return;
        }

        public async Task<IEnumerable<User>> GetAllUser()
        {
            var y = await context.User.ToListAsync();
            return y;
        }

        public async Task<User> GetDetailsById(int id)
        {
            var user = await context.User.FirstOrDefaultAsync(e => e.Id == id);
            if (user == null)
            {
                return null;
            }

            var userModel = new User
            {
                Id = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                PdfFile = user.PdfFile,
                PdfBase64Data = user.PdfBase64Data,
                PdfFileName = user.PdfFileName
            };

            return userModel;
        }
        public Task UpdateUser(User user)
        {
            return Task.FromResult(0);
        }
    }
}
