using StudentManagementSystem1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem1.Service
{
    public class StudentService 
    {
        public static List<Student> students = new List<Student>()
        {
            new Student { Id = 1, FirstName = "Ulhas", LastName = "Sonkusre", Gender = "Male",Age = 26, Class = "Class X", Address = "Mumbai" ,DateOfBirth = new DateTime(1998, 1, 1), },
            new Student { Id = 2, FirstName = "Navya ", LastName = "Patel", Gender = "Female", Age = 24, Class = "Class XV", Address = "Banglore", DateOfBirth = new DateTime(2000, 5, 15) },
        };

        public static List<Student> GetStudents() => students;
        public static Student GetStudentById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            if (student != null)
            {
                return new Student
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Gender = student.Gender,
                    Age = student.Age,
                    Class = student.Class,
                    Address = student.Address,
                    DateOfBirth = student.DateOfBirth,
                };
            }
            return null;
        }

        public static void UpdateStudent(int Id, Student student)
        {
            if (Id != student.Id) return;

            var studentToUpdate = students.FirstOrDefault(x => x.Id == Id);
            if (studentToUpdate != null)
            {
                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.Gender = student.Gender;
                studentToUpdate.Age = student.Age;
                studentToUpdate.DateOfBirth = student.DateOfBirth;
                studentToUpdate.Class = student.Class;
                studentToUpdate.Address = student.Address;
            }

        }
        public static void AddStudent(Student student)
        {
            var maxId = students.Max(x => x.Id);
            student.Id = maxId + 1;

           //student= TrimStudentData(student);
            students.Add(student);
        }
        public static void DeleteStudent(int Id)
        {
            var studentToDelete = students.FirstOrDefault(s => s.Id == Id);
            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);
            }
        }
       
        public static Student TrimStudentData(Student student)
        {

            student.FirstName = student.FirstName.Trim();
            student.LastName = student.LastName.Trim();
            student.Gender = student.Gender.Trim();
            student.Class = student.Class?.Trim();
            student.Address = student.Address?.Trim();
           return student;
        }
        public static List<Student> SearchStudents(string searchText)
        {
           
            searchText = searchText.ToLower();

          
            var filteredStudents = students.Where(s =>
                s.FirstName.ToLower().Contains(searchText) ||
                s.LastName.ToLower().Contains(searchText) ||
                s.Age.ToString().Contains(searchText) 
            ).ToList();

            return filteredStudents;
        }

    }
}
