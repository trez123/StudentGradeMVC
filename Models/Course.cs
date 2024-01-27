using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentGradeMVC.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Display(Name = "Course Name")]
        [Column(TypeName = "varchar (50)")]
        public string Name { get; set; }


        [Display(Name = "Description")]
        [Column(TypeName = "varchar (250)")]
        public string? Description { get; set; }


        [Display(Name = "Student Limit")]
        public int? MaxStudent { get; set; }

    }
}
