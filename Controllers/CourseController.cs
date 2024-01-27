using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using StudentGradeMVC.Data;
using StudentGradeMVC.Models;
using StudentGradeMVC.Models.ModelView;

namespace StudentGradeMVC.Controllers
{
    public class CourseController : Controller
    {
        private readonly SchoolDbContext _context;
        public CourseController(SchoolDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Course> lstsCourses = _context.COURSE;
            return View(lstsCourses);
        }

        //GET Upsert
        public IActionResult Upsert(int? id)
        {
            Course course = new Course();
            if (id == null)
            {
                return View(course);
            }
            else
            {
                course = _context.COURSE.Find(id);
                if (course == null)
                {
                    return NotFound();
                }
                return View(course);
            }
        }

        //POST Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Upsert(Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.Id == 0)
                {
                    _context.COURSE.Add(course);
                }
                else
                {
                    _context.COURSE.Update(course);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(course);
            }
        }

    }
}
