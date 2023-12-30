using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Test.DTOs.Company
{
    public class GetProjectDTO
    {
        [Required]
        public int ProjectID { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public int VendorID { get; set; }
    }
}
