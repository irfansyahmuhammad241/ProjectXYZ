using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Technical_Test.Utilities.Enums;

namespace Technical_Test.Models
{
    public class User 
    {
        [Key]
        [Column("UserID", TypeName = "int")]
        public int UserID { get; set; }
        [Column("Email", TypeName = "nvarchar(255)")]
        public string Email { get; set; }
        [Column("Password", TypeName = "nvarchar(255)")]
        public string Password { get; set; }
        [Column("UserType")]
        public UserType UserType { get; set; }

        //Foreign Key
        public int CompanyID { get; set; }
        public int ManagerID { get; set; }
        //Cardinality
        public Company Company { get; set; }
        public ManagerLogistics ManagerLogistics { get; set; }
        public Vendor Vendor { get; set; }
    }
}
