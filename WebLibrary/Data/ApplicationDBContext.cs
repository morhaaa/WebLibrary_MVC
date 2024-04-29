using Microsoft.EntityFrameworkCore;
using WebLibrary.Models;

namespace WebLibrary.Data {
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) {
        }
        
        public DbSet <Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Name ="Action" },
                new Category { Id = 2, Name ="SciFi" },
                new Category { Id = 3, Name ="Horror" }
            );
        }
    }
}

