using DoxaFinal.Models.Form;
using Microsoft.EntityFrameworkCore;
  
namespace DoxaFinal.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Movement> Movements { get; set; }
        public DbSet<Document> Documents { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<Part> Parts { get; set; }

    }
}
