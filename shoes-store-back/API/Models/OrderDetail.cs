using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        public int OrdersID { get; set; }
        public int ProductID { get; set; }
        public int VariantID {  get; set; }
        public int Quantity { get; set; }
        public Decimal Total { get; set; }
        
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductVariant Variant { get; set; }
    }
}
