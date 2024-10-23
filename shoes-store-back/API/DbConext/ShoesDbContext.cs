using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DbConext
{
    public class ShoesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-IVP2BT1;Initial Catalog=BE_CODE_THUE;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
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
