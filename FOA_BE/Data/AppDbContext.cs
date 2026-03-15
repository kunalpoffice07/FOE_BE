using FOA_BE.Models;
using Microsoft.EntityFrameworkCore;

namespace FOA_BE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }  
    }
}
