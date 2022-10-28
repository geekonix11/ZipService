using Microsoft.EntityFrameworkCore;
using ZipService.Models;

namespace ZipService.Data{

    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {

            
        }

        public DbSet<Account> Accounts {get; set;}
        public DbSet<User> Users { get; set; }
    }
}