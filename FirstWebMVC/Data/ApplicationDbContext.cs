using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Models.Entities;

namespace FirstWebMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Faculty>().HasData(
                new Faculty { Id = 1, FacultyName = "CNTT" },
                new Faculty { Id = 2, FacultyName = "Kinh tế" },
                new Faculty { Id = 3, FacultyName = "Dầu khí" },
                new Faculty { Id = 4, FacultyName = "Xây dựng" }
            );
        }
        public DbSet<FirstWebMVC.Models.Entities.Customer> Customer { get; set; } = default!;
        public DbSet<FirstWebMVC.Models.Entities.Product> Product { get; set; } = default!;
        public DbSet<FirstWebMVC.Models.Entities.Order> Order { get; set; } = default!;
        public DbSet<FirstWebMVC.Models.Entities.OrderDetail> OrderDetail { get; set; } = default!;
    }
}