using System;

namespace LINQ_exercises
{
    public class Program
    {
        static void Main(string[] args)
        {
            UniversityManager universityManager = new UniversityManager();

            universityManager.GetMaleStudents();
            universityManager.GetFemaleStudents();
            universityManager.GetStudentsSortedByAge();
            universityManager.GetStudentsGroupedByUniversity();
            universityManager.GetStudentsFromBejingUniversity();
            universityManager.GetStudentsFromUniversityById(1);
            universityManager.GetNamesStudentsAndUniversities();

            Console.ReadLine();
        }
    }
}
