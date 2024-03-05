using AspCoreWebAppMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace AspCoreWebAppMVC.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<User> User { get; set; }
    }
}
