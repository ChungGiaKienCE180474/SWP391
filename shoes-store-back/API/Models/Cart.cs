using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Cart")]
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int AccountID { get; set; }
        public int ProductID { get; set; }
        public int VariantID { get; set; }
        public int Quantity { get; set; }   

        public virtual Account? Account { get; set; }
        public virtual Product? Product { get; set; }
        public virtual ProductVariant? Variant { get; set; }
    }
}
