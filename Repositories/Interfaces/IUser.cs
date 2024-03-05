using AspCoreWebAppMVC.Models;

namespace AspCoreWebAppMVC.Repositories.Interfaces
{
    public interface IUser : IDisposable
    {
        Task<IEnumerable<User>> GetAllUser();

        Task<User> GetDetailsById(int id);

        Task<int> CreateUser(User user);

        Task UpdateUser(User user);

        Task DeleteUser(int id);


    }
}
