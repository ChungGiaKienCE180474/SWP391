using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrdersID { get; set; }
        public int AccountID {  get; set; }
        [MaxLength(255)]
        public String OrderAddress { get; set; }
        [MaxLength(100)]
        public String PaymentMethod { get; set; }   
        public Decimal TotalPrice { get; set; }
        [MaxLength(100)]
        public String OrderStatus { get; set; }

        public Account account { get; set; }

    }
}
