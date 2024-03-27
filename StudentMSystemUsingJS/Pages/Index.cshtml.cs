using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem1.Models;
using StudentManagementSystem1.Service;

namespace StudentMSysUsingJS1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly StudentManagementSystem1.Service.StudentService _studentService;

        public IndexModel(StudentManagementSystem1.Service.StudentService studentService)
        {
            _studentService = studentService;
        }

        public List<Student> Students { get; set; }

        public void OnGet()
        {
            Students = StudentManagementSystem1.Service.StudentService.GetStudents();
        }
    }
}