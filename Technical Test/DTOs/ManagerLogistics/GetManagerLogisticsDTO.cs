using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Test.DTOs.Company
{
    public class GetManagerLogisticsDTO
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
