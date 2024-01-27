using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentGradeMVC.Data;
using StudentGradeMVC.Models;
using StudentGradeMVC.Models.ModelView;

namespace StudentGradeMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public StudentController(SchoolDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> lstsStudents = _context.STUDENT;
            foreach (Student student in lstsStudents)
            {
                student.Course = _context.COURSE.FirstOrDefault(iquery => iquery.Id == student.CourseID);
                //In the model we had a virtual course object in the student class. So that means each student
                //object has a course object. So we are saying here we are creating this object and defining its
                //value. The First/Default funtions returns the first instance of when the condition in the brackets 
                //is true. iQuery represents a temp object for the course. So it reads where course id (FROM THE COURSE TABLE
                //is equal to student.CourseID from the STUDENT TABLE. So its going to create that course object using that. 
            }
            return View(lstsStudents);
        }
        //Get
        public IActionResult Upsert(int? id)
        {
            //IEnumerable<SelectListItem> courseDropdown = 
            //ViewBag.CourseDropdown = courseDropdown;
            //ViewData["CourseDropdown"] = courseDropdown;
            StudentVM studentVM = new StudentVM()
            {
                Student = new Student(),
                CourseSelectList = _context.COURSE.Select(iQuery => new SelectListItem
                {
                    Text = iQuery.Name,
                    Value = iQuery.Id.ToString()
                })
            };

            //Student stud = new Student();
            if (id == null)
            {
                //This is for create student
                return View(studentVM);
            }
            else
            {
                //This is to edit student details
                studentVM.Student = _context.STUDENT.Find(id);
                if (studentVM.Student == null)
                {
                    return NotFound();
                }
                return View(studentVM);
            }
        }

        //POST UPSERT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(StudentVM studentVM)
        {

            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                string webRoot = _webHostEnvironment.WebRootPath;
                if (studentVM.Student.Id == 0)
                {
                //string fileName = "test.jpg";
                string uploadPath = webRoot + AppConst.UploadPath;
                string fileName = Guid.NewGuid().ToString();
                string ext = Path.GetExtension(files[0].FileName);
                using (var fs = new FileStream(Path.Combine(uploadPath, fileName + ext), FileMode.Create))
                {
                    files[0].CopyTo(fs);
                }
                studentVM.Student.StudentImage = fileName + ext;
                //studentVM.Student.StudentImage = fileName;
                    _context.STUDENT.Add(studentVM.Student);
                }
                else
                {
                    _context.STUDENT.Update(studentVM.Student);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                studentVM.CourseSelectList = _context.COURSE.Select(iQuery => new SelectListItem
                {
                    Text = iQuery.Name,
                    Value = iQuery.Id.ToString()
                });

                return View(studentVM);
            }
        }

    }
}
