using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace StudentGradeMVC.Models.ModelView
{
    public class GradeVM
    {
        public StudentVM Student { get; set; }
        public Grade Grade{ get; set; }

    }
}
