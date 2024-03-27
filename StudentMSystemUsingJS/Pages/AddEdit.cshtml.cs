using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagementSystem1.Models;
using StudentManagementSystem1.Service;

namespace StudentMSysUsingJS1.Pages
{
    public class AddEditModel : PageModel
    {
        private readonly StudentService _studentService;

        [BindProperty]
        public Student Student { get; set; }
        [BindProperty]
        public bool DeleteFlag { get; set; }
        public AddEditModel(StudentService studentService)
        {

            _studentService = studentService;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                
                Student = StudentManagementSystem1.Service.StudentService.GetStudentById(id.Value);
            }
            else
            {
               
                Student = new Student();
            }

            return Page();
        }

        public IActionResult OnPost()
        {

            if (DeleteFlag)
            {
                // Delete the student and redirect to Index
               StudentService.DeleteStudent(Student.Id);

                return RedirectToPage("Index");
            }
        
            else
            {
                if (Student.Id != 0)
                {
                    StudentService.UpdateStudent(Student.Id, Student);
                }
                else
                {
                    StudentService.AddStudent(Student);
                }
                // StudentService.UpdateStudent(Student.Id, Student);
                return RedirectToPage("Index");
            }
        

            return Page();
        }
    }
}
