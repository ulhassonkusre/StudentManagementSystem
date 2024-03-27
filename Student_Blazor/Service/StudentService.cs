namespace Service
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
            //private static  List<Student> students;

            //public  StudentService() 
            //{
            //    // Initialize with some sample data
            //    students = new List<Student>
            //    {
            //    new Student { Id = 1, FirstName = "Ulhas", LastName = "Sonkusre", Gender = "Male",Age = 26, Class = "Class X", Address = "Mumbai" ,DateOfBirth = new DateTime(1998, 1, 1), },
            //    new Student { Id = 2, FirstName = "Navya ", LastName = "Patel", Gender = "Female", Age = 24, Class = "Class XV", Address = "Banglore", DateOfBirth = new DateTime(2000, 5, 15) },
            //        // Add more sample data as needed
            //};
            //}

            ////public void AddStudent(Student student)
            ////{
            ////    Console.WriteLine("Student added");
            ////    if (student.Id == 0)
            ////    {

            ////        student.Id = students.Count + 1;
            ////        var id = student.Id;
            ////        TrimStudentData(student);
            ////        students.Add(student);

            ////    }

            ////}
            //public static void AddStudent(Student student)
            //{
            //    var maxId = students.Max(x => x.Id);
            //    student.Id = maxId + 1;
            // //   TrimStudentData(student);
            //    students.Add(student);
            //}

            //public static void DeleteStudent(int Id)
            //{
            //    var studentToDelete = students.FirstOrDefault(s => s.Id == Id);
            //    if (studentToDelete != null)
            //    {
            //        students.Remove(studentToDelete);
            //    }
            //}

            //public static Student GetStudentById(int id)
            //{
            //    return students.SingleOrDefault(s => s.Id == id);
            //}

            //public static  List<Student> GetStudents() => students;

            //public static void UpdateStudent(Student student)
            //{
            //    var existingStudent = students.FirstOrDefault(s => s.Id == student.Id);
            //    if (existingStudent != null)
            //    {
            //        var getExistingStudent = GetStudentById(student.Id);
            //        getExistingStudent.FirstName = student.FirstName.Trim();
            //        getExistingStudent.LastName = student.LastName.Trim();
            //        getExistingStudent.Gender = student.Gender.Trim();
            //        getExistingStudent.Age = student.Age;
            //        getExistingStudent.Class = student.Class;
            //        getExistingStudent.Address = student.Address;
            //        getExistingStudent.DateOfBirth = student.DateOfBirth;
            //    }

            //}



            ////public Student11 GetStudentById(int id)
            ////{
            ////    return _students.FirstOrDefault(s => s.Id == id);
            ////}

            ////public void AddOrUpdateStudent(Student students)
            ////{
            ////    if (students.id == 0)
            ////    {
            ////        // Add new student
            ////        students.id = students.Count + 1;
            ////        TrimStudentData(students);
            ////        _students.Add(students);
            ////    }
            ////    else
            ////    {
            ////        // Update existing student
            ////var existingStudent = students.FirstOrDefault(s => s.id == students.id);
            ////   if (existingStudent != null)
            ////   {
            ////       TrimStudentData(students);
            ////       existingStudent.firstName = students.FirstName;
            ////       existingStudent.lastName = students.LastName;
            ////       existingStudent.gender = students.Gender;
            ////       existingStudent.age = students.Age;
            ////       existingStudent.stu_Class = students.Class;
            ////       existingStudent.address = students.Address;
            ////       existingStudent.birthDate = students.DateOfBirth;
            //// Update other properties as needed
            ////        }
            ////    }
            ////}
            ////public void DeleteStudent(int id)
            ////{
            ////    var studentToDelete = _students.FirstOrDefault(s => s.id == id);
            ////    if (studentToDelete != null)
            ////    {
            ////        _students.Remove(studentToDelete);
            ////    }

            ////}

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
