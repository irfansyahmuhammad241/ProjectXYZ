using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Test.Models
{
    public class Vendor
    {
        [Key]
        [Column("VendorID", TypeName = "int")]
        public int VendorID { get; set; }

        [Column("vendorName", TypeName = "nvarchar(255)")]
        public string VendorName { get; set; }

        [Column("businessType", TypeName = "nvarchar(255)")]
        public string BusinessType { get; set; }

        [Column("companyType", TypeName = "nvarchar(255)")]
        public string CompanyType { get; set; }

        // Foreign Key
        public int UserID { get; set; }

        // Cardinality
        public User User { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
