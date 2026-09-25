using Microsoft.AspNetCore.Mvc;
using IT_ELECTIVE_PREFINALS_PROJECT.Models;

namespace IT_ELECTIVE_PREFINALS_PROJECT.Controllers
{
    public class StudentController : Controller
    {
        // Simple in-memory list para hindi na kailangan ng database
        public static List<Student> studentList = new List<Student>();

        // Display List
        public IActionResult Index()
        {
            return View(studentList);
        }

        // Show Create Form
        public IActionResult Create()
        {
            return View();
        }

        // Save New Student
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                studentList.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // Delete Student
        public IActionResult Delete(int id)
        {
            var student = studentList.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                studentList.Remove(student);
            }
            return RedirectToAction("Index");
        }
    }
}