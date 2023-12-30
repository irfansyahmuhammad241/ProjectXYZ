using System.ComponentModel.DataAnnotations;

namespace Technical_Test.DTOs.Company
{
    public class NewVendorDTO
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
