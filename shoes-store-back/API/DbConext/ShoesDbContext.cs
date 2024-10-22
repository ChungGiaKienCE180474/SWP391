using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DbConext
{
    public class ShoesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SE1803_SWP391_Group4;Integrated Security=True;Trust Server Certificate=True");
        }

        public DbSet<Account> accounts { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderDetail> ordersDetail { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Import> import { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<ProductVariant> productsVariant { get; set; }
        public DbSet<OrderStatusLog> ordersStatusLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasKey(o => new { o.OrdersID, o.ProductID, o.VariantID });
            modelBuilder.Entity<OrderStatusLog>().HasKey(ot => new { ot.OrderID, ot.AccountID });
        }
    }
}
