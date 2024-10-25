using API.DbConext;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DAO
{
    public class ProductDAO
    {
        private readonly ShoesDbContext db;
        public ProductDAO(ShoesDbContext _db)
        {
            this.db = _db;
        }

        public List<Product> GetProducts()
        {
            var listProduct = db.products.ToList();
            return listProduct;
        }
        
        
    }
}
