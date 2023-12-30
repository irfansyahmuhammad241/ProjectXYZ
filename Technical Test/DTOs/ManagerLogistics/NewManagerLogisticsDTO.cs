using System.ComponentModel.DataAnnotations;

namespace Technical_Test.DTOs.Company
{
    public class NewManagerLogisticsDTO
    {
        [Required]
        public int ManagerID { get; set; }
        [Required]
        public string ManagerName { get; set; }

        [Required]
        public string ManagerEmail { get; set; }

        [Required]
        public string ManagerPhone { get; set; }
    }
}
