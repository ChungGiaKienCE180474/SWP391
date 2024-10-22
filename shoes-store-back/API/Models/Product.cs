using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [MaxLength(500)]
        public String ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        [MaxLength(500)]
        public String ProductImg { get; set; }
        [MaxLength(500)]
        public String ProductCategory { get; set; }
        [MaxLength(500)]
        public String ProductDescription { get; set; }
        [MaxLength(500)]
        public String ProductStatus {  get; set; }  
    }
}
