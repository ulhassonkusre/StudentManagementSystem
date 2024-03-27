using StudentManagementSystem1.Models;
namespace StudentManagementSystem1.Service
{
   
        public interface IStudentService
        {
            List<Student> GetStudents();

            Student GetStudentById(int Id);

           void UpdateStudent(Student student);

            void AddStudent(Student student);
            void DeleteStudent(int Id);

        
    }
    
}
