using Microsoft.EntityFrameworkCore;

namespace API.DbConext
{
    public class ShoesDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=SE1803_SWP391_Group4;Integrated Security=True;Trust Server Certificate=True";
        }
    }
}
