namespace LINQ_exercises
{
    public class University
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            System.Console.WriteLine("University {0} with id:{1}",Name, Id);
        }
    }
}
