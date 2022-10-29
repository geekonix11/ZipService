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

         protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<User>()
        //     .HasIndex(u => u.Email)
        //     .IsUnique(true);

            //   modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);

            modelBuilder.Entity<User>()
    .HasIndex(account => account.Email)
      .IsUnique();
    }
    }
}