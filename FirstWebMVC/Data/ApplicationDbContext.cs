using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models.Entities;

namespace FirstWebMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Khai báo DbSet ở đây
        public DbSet<Student> Students { get; set; }
    }
}