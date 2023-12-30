using System.ComponentModel.DataAnnotations;
using Technical_Test.Utilities.Enums;

namespace Technical_Test.DTOs.Company
{
    public class UpdateUserDTO
    {
        [Required]
        public int UserID { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserType UserType { get; set; }

        public int CompanyID { get; set; }
        public int ManagerID { get; set; }
    }
}
