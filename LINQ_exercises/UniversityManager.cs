using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_exercises
{
    public class UniversityManager
    {
        List<University> Universities;
        List<Student> Students;

        public UniversityManager()
        {
            Universities = new List<University>();
            Students = new List<Student>();

            //Let's add some Universities
            Universities.Add(new University { Id = 1, Name = "Yale" });
            Universities.Add(new University { Id = 2, Name = "Beijing Tech" });

            //Let's add some Students
            Students.Add(new Student { Id = 1, Name = "Carla", Gender = "female", Age = 17, UniversityId = 1 });
            Students.Add(new Student { Id = 2, Name = "Toni", Gender = "male", Age = 21, UniversityId = 1 });
            Students.Add(new Student { Id = 3, Name = "Frank", Gender = "male", Age = 22, UniversityId = 2 });
            Students.Add(new Student { Id = 4, Name = "Leyla", Gender = "female", Age = 19, UniversityId = 2 });
            Students.Add(new Student { Id = 5, Name = "James", Gender = "trans-gender", Age = 25, UniversityId = 2 });
            Students.Add(new Student { Id = 6, Name = "Linda", Gender = "female", Age = 22, UniversityId = 2 });
        }

        public void GetMaleStudents()
        {
            IEnumerable<Student> maleStudents =
                from student in Students
                where student.Gender == "male"
                select student;

            Console.WriteLine("Male students:");
            foreach (var student in maleStudents)
            {
                student.Print();
            }
            Console.WriteLine();
        }

        public void GetFemaleStudents()
        {
            IEnumerable<Student> femaleStudents =
                from student in Students
                where student.Gender == "female"
                select student;
            Console.WriteLine("Female students:");
            foreach (var student in femaleStudents)
            {
                student.Print();
            }
            Console.WriteLine();
        }

        public void GetStudentsSortedByAge()
        {
            IEnumerable<Student> studentsSortedByAge =
                from student in Students
                orderby student.Age
                select student;

            Console.WriteLine("Students, sorted by age:");

            foreach (Student student in studentsSortedByAge)
            {
                student.Print();
            }
            Console.WriteLine();
        }

        public void GetStudentsFromBejingUniversity()
        {
            IEnumerable<Student> bejingStudents =
                from student in Students
                join university in Universities on student.UniversityId equals university.Id
                where university.Id == 2
                select student;

            Console.WriteLine("Students from Bejing University:");
            foreach (var student in bejingStudents)
            {
                student.Print();
            }
            Console.WriteLine();
        }

        public void GetStudentsFromUniversityById(int universityId)
        {
            IEnumerable<Student> students =
                from student in Students
                join university in Universities on student.UniversityId equals university.Id
                where university.Id == universityId
                select student;

            IEnumerable<University> university1 =
                from university in Universities
                where university.Id == universityId
                select university;

            // Since 1 university is expected to exist with single Id, accessing it via ElementAt() extension
            Console.WriteLine("Students from {0} university", university1.ElementAt(0).Name);

            foreach (Student student in students)
            {
                student.Print();
            }
            Console.WriteLine();
        }

        public void GetStudentsGroupedByUniversity()
        {
            var studentWithUniversity =
                from university in Universities
                join student in Students on university.Id equals student.UniversityId into studentGroup
                from student1 in studentGroup
                select new
                {
                    id = student1.Id,
                    name = student1.Name,
                    gender = student1.Gender,
                    age = student1.Age,
                    university = university.Name
                };

            Console.WriteLine("Students, with university name:");

            foreach (var student in studentWithUniversity)
            {
                Console.WriteLine($"Student {student.name} with Id {student.id}, gender {student.gender} " +
                    $"and age {student.age} from university {student.university}");
            }
            Console.WriteLine();
        }

        public void GetNamesStudentsAndUniversities()
        {
            var namesOfStudentsAndUniversities =
                from student in Students
                join university in Universities
                on student.UniversityId equals university.Id
                orderby student.Name
                select new { studentName = student.Name, universityName = university.Name };

            Console.WriteLine("Student name and university name:");
            foreach (var col in namesOfStudentsAndUniversities)
            {
                Console.WriteLine("Student: {0}, from university: {1}", col.studentName,col.universityName);
            }
            Console.WriteLine();
        }
    }
}
