using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentGradeMVC.Models;

namespace StudentGradeMVC.Data
{
    public class SchoolDbContext : IdentityDbContext<IdentityUser>
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {

        }
        public DbSet<Student> STUDENT { get; set; }
        public DbSet<Course> COURSE { get; set; }
        public DbSet<Grade> GRADE { get; set; }
    }
}
