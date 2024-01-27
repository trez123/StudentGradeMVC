using Microsoft.AspNetCore.Mvc;
using StudentGradeMVC.Data;
using StudentGradeMVC.Models;
using StudentGradeMVC.Models.ModelView;
using System.Diagnostics;

namespace StudentGradeMVC.Controllers
{
    public class GradeController : Controller
    {
        private readonly SchoolDbContext _context;
        public GradeController(SchoolDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Grade> lstGrades = _context.GRADE;
            foreach (Grade grade in lstGrades)
            {
                grade.Student = _context.STUDENT.FirstOrDefault(iquery => iquery.Id == grade.StudentID);
                grade.Student.Course= _context.COURSE.FirstOrDefault(iquery => iquery.Id == grade.Student.CourseID);
            }
            return View(lstGrades);
        }
        //GET Upsert
        public IActionResult Upsert(int? id)
        {
            Grade gradeVM = new Grade();

            if (id == null)
            {
                //This is for create student

                gradeVM.Student = _context.STUDENT.FirstOrDefault(iquery => iquery.Id == gradeVM.StudentID);
                return View(gradeVM);
            }
            else
            {
                //This is to edit student details
                gradeVM = _context.GRADE.Find(id);
                gradeVM.Student = _context.STUDENT.FirstOrDefault(iquery => iquery.Id == gradeVM.StudentID);
                string email = gradeVM.Student.Email;

                if (gradeVM == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.STUDENT.FirstOrDefault(iquery => iquery.Id == gradeVM.StudentID);
                }
                return View(gradeVM);
            }
        }
        //POST Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Grade grade)
        {
            //if (ModelState.IsValid)
            //{
                if (grade.Id == 0)
                {
                    _context.GRADE.Add(grade);
                }
                else
                {
                    _context.GRADE.Update(grade);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View(grade);
            //}
        }
    }
}
