using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentGradeMVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [Column(TypeName = "varchar (50)")]
        public string Name { get; set; }


        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MMM-dd-yy}")]
        public DateTime? DOB { get; set; }


        [Required]
        [Display(Name = "Address ln1")]
        [Column(TypeName = "varchar (250)")]
        public string Addressln1 { get; set; }


        [Required]
        [Display(Name = "Address ln2")]
        [Column(TypeName = "varchar (250)")]
        public string Addressln2 { get; set; }


        [Display(Name = "Phone Number")]
        [Column(TypeName = "varchar (11)")]
        public string? Phone { get; set; }


        [Required]
        [Display(Name = "Email Address")]
        [Column(TypeName = "varchar (250)")]
        public string Email { get; set; }



        [Display(Name = "TikTok Tag")]
        [Column(TypeName = "varchar (50)")]
        public string? TikTokTag { get; set; }


        [Display(Name = "Instagram Tag")]
        [Column(TypeName = "varchar (50)")]
        public string? IGTag { get; set; }



        [Column(TypeName = "varchar (MAX)")]
        public string? StudentImage { get; set;}


        [Display(Name = "Course")]
        public int? CourseID { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course? Course { get; set;}

    }
}
