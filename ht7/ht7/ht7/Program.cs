using System;

namespace ht7
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isTyping = true;
            HashSet<Student> presentStudents = new HashSet<Student> { };
            Dictionary<int, Student> students = new Dictionary<int, Student>();

            while (isTyping)
            {
                Console.Clear();

                Console.Write("===Lecture 7===\nEnter your full name: ");
                string studentName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(studentName))
                {
                    Console.WriteLine("Wrong input!");
                    Console.ReadKey();
                    continue;
                }

                var newStudent = new Student(studentName);
                presentStudents.Add(newStudent);
                students.Add(newStudent.Id, newStudent);
                
                Console.WriteLine("Register another student? (Y/N)");
                if (Console.ReadLine().ToUpper() == "Y")
                {
                    continue;
                }
                isTyping = false;
            }

            var student1 = new Student("Ihor Pylypenko");
            presentStudents.Add(student1);
            student1.Id = 19;

            if (presentStudents.Contains(student1))
            {
                Console.WriteLine("True");
            } else 
            { 
                Console.WriteLine("False"); 
            }

            /*
             Contains() returns false, because field Id affects it's 
             GetHashCode(), object student1 gets in the wrong bucket
             and this object gets lost, despite it's physically 
             present in memory
            */
        }
    }
}