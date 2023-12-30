using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Test.DTOs.Company
{
    public class GetCompanyDTO
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
