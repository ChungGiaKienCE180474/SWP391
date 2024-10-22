using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("OrderStatusLog")]
    public class OrderStatusLog
    {
        public int OrderID { get; set; }
        public int AccountID { get; set; }
        public DateTime StatusDate { get; set; }
        [MaxLength(100)]
        public String OrderStauts { get; set; }

        public virtual Order Order { get; set; }    
        public virtual Account Account { get; set; }

    }
}
