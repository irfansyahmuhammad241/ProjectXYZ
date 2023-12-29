using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Test.Models
{
    public class Company 
    {
        [Key]
        [Column("companyID", TypeName = "int")]
        public int CompanyID { get; set; }
        [Column("companyName", TypeName = "nvarchar(255)")]
        public string CompanyName { get; set; }
        [Column("companyEmail", TypeName = "nvarchar(255)")]
        public string CompanyEmail { get; set; }
        [Column("companyPhone", TypeName = "nvarchar(255)")]
        public string CompanyPhoneNumber { get; set; }
        [Column("approvalStatus", TypeName = "nvarchar(255)")]
        public string ApprovalStatus { get; set; }
        [Column("companyPhoto")]
        public byte[] CompanyPhoto { get; set; }


        //cardinality
        public User User { get; set; }

    }
}
