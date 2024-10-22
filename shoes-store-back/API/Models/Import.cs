using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Import")]
    public class Import
    {
        [Key]
        public int ImportID {  get; set; }  
        public DateTime ImportDate { get; set; }
        public int AccountID { get; set; }
        public int ProductID { get; set; }  
        public int VariantID {  get; set; } 
        public int Quantity { get; set; }

        public virtual Account Account { get; set; }
        public virtual Product Product { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
       

    }
}
