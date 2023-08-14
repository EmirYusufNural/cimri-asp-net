using cimri.entity;
using Microsoft.EntityFrameworkCore;
namespace cimri.entity
{
    public class EntityContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=cimri2;User Id=sa;Password=5316; TrustServerCertificate=True;");
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Brochure> Brochures { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<FavoriteItem> FavoriteItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
    }
}