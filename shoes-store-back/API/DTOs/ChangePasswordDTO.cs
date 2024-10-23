namespace API.DTOs
{
    public class ChangePasswordDTO
    {
        public int accountID { get; set; }
        public String OldPassword { get; set; }
        public String NewPassword { get; set; }
    }
}
