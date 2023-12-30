using System.ComponentModel.DataAnnotations;
using Technical_Test.Utilities.Enums;

namespace Technical_Test.DTOs.Authorization
{
    public class RegisterDTO
    {
        //Company
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyEmail { get; set; }
        [Required]
        public string CompanyPhoneNumber { get; set; }
        public byte[] CompanyPhoto { get; set; }

        //User
        [Required]
        public string Password { get; set; }
        [Required]
        public UserType UserType { get; set; }
     

    }
}
