using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    [Table("Account")]
    public class Account
    {
        [Key]
        public int AccountID { get; set; }
        [Required]
        [MaxLength(50)]
        public String AccountEmail { get; set; }
        [MaxLength(32)]
        [Required]
        public String Password { get; set; }
        [MaxLength(32)]
        public String? AccountName { get; set; }
        [MaxLength(10)]
        public String? Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        [MaxLength(10)]
        public String? Phone { get; set; }
        [MaxLength(255)]
        public String? AccountAddress { get; set; }
        [MaxLength(5)]
        [Required]
        public String Role {  get; set; }
        [MaxLength(10)]
        public String Status { get;set; }

        [MaxLength(20)]
        public String? OTP { get; set; }
        public DateTime? OTP_Time { get; set; }


    }
}
