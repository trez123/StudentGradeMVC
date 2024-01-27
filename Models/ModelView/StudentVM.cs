using Microsoft.AspNetCore.Mvc.Rendering;

namespace StudentGradeMVC.Models.ModelView
{
    public class StudentVM
    {
        public virtual Student Student { get; set; }
        public virtual IEnumerable<SelectListItem>? CourseSelectList { get; set; }
    }
}
