using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ht7
{
    internal class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        private static int _counter = 0;

        SortedDictionary<DateTime, int> studentJournal = new SortedDictionary<DateTime, int>();

        public Student(string fullName)
        {
            _counter++;
            this.FullName = fullName;
            this.Id = _counter;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Student other = obj as Student;

            return Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public string GetStudentName(Dictionary<int, Student> students)
        {
            bool isTyping = true;
            while (isTyping)
            {
                int studentId;
                Student student;

                Console.Write("Enter student's ID: ");
                if (!int.TryParse(Console.ReadLine(), out studentId))
                {
                    Console.WriteLine("Wrong input");
                    continue;
                }
                /*
                 Method Dictionary.TryGetValue() is faster than List.FirstOrNull(), because
                 Dictionary.TryGetValue() instantly jumps to value when gets it's key, 
                 unlike List.FirstOrNull(), which looks at every value until finds the
                 right one.
                */
                if (!students.TryGetValue(studentId, out student))
                {
                    Console.WriteLine("Student was not found");
                    continue;
                }
                return student.FullName;
            }
            return string.Empty;
        }

        public void GetStudentJournal()
        {
            foreach (var score in studentJournal)
            {
                Console.WriteLine($"{score.Key}: {score.Value}");
            }
        }
    }
}
