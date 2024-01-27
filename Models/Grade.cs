using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentGradeMVC.Models
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        [Display (Name ="Assignment Name")]
        [Column(TypeName = "varchar (50)")]
        public string Name { get; set; }


        [Column(TypeName = "varchar (250)")]
        public string? Description { get; set; }

        [Column(TypeName = "decimal (18,0)")]
        public decimal Score { get; set; }

        public int? StudentID { get; set; }
        [ForeignKey("StudentID")]
        public virtual Student? Student { get; set; }
        //public Course? Course { get; set; }
    }
}
