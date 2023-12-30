using System.ComponentModel.DataAnnotations;

namespace Technical_Test.DTOs.Company
{
    public class UpdateProjectDTO
    {
        [Required]
        public int ProjectID { get; set; }

        [Required]
        public string ProjectName { get; set; }

        [Required]
        public int VendorID { get; set; }
    }
}
