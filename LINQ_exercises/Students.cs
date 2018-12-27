using System;
namespace LINQ_exercises
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Foreign Key
        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine($"Student {Name} with Id {Id}, gender {Gender} " +
                $"and age {Age} from university Id {UniversityId}");
        }
    }
}
