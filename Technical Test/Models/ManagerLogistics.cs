using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Test.Models
{
    public class ManagerLogistics 
    {
        [Key]
        [Column("ManagerID", TypeName = "int")]
        public int ManagerID { get; set; }
        [Column("managerName", TypeName = "nvarchar(255)")]
        public string ManagerName { get; set; }

        [Column("managerEmail", TypeName = "nvarchar(255)")]
        public string ManagerEmail { get; set; }

        [Column("managerPhone", TypeName = "nvarchar(255)")]
        public string ManagerPhone { get; set; }

        //Cardinality
        public User User { get; set; }
    }
}
