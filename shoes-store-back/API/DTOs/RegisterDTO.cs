using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDTO
    {
        [Required]
       public String AccountEmail { get; set; }
        [Required]
        public String Password { get; set; }
       public String Role = "User";
       public String Status = "InActive";
    }
}
