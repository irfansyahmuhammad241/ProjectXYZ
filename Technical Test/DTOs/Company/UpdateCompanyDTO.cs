using System.ComponentModel.DataAnnotations;

namespace Technical_Test.DTOs.Company
{
    public class UpdateCompanyDTO
    {
        [Required]
        public int CompanyID { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyEmail { get; set; }
        [Required]
        public string CompanyPhoneNumber { get; set; }
        [Required]
        public string ApprovalStatus { get; set; }

        public byte[] CompanyPhoto { get; set; }
    }
}
