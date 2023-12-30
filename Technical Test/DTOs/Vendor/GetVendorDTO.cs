using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Test.DTOs.Company
{
    public class GetVendorDTO
    {
        [Required]
        public int VendorID { get; set; }

        [Required]
        public string VendorName { get; set; }

        [Required]
        public string BusinessType { get; set; }

        [Required]
        public string CompanyType { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}
