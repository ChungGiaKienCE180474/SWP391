using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Comment")]
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public int ProductID { get; set; }
        public int AccountID { get; set; }
        [MaxLength(255)]
        public String Conent {  get; set; }
        public DateTime CreateDate { get; set; }
        [MaxLength(20)]
        public String CommentStatus { get; set; }
        public virtual Account Account { get; set; }
        public virtual Product Product { get; set; }

    }
}
