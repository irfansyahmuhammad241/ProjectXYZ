﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Technical_Test.Models
{
    public class Project
    {
        [Key]
        [Column("ProjectID", TypeName = "int")]
        public int ProjectID { get; set; }

        [Column("projectName", TypeName = "nvarchar(255)")]
        public string ProjectName { get; set; }

        // Foreign Key
        public int VendorID { get; set; }

        // Cardinality
        public Vendor Vendor { get; set; }
    }
}
