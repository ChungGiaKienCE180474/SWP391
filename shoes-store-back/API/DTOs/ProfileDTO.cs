using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ProfileDTO
    {
        public String AccountEmail { get; set; }
        public String AccountName { get; set; }
        public String Gender { get; set; }
        public String BirthDay { get; set; }
        public String Phone {  get; set; }
        public String AccountAddress { get; set; }
    }
}
