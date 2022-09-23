using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static List<Student> students = new List<Student>
        {
            new Student {First = "Svetlana", Last = "Omelchenko", Id = 111, Scores = new List<int> {97, 92, 81, 60}},
            new Student {First = "Claire", Last = "O'Donnell", Id = 112, Scores = new List<int> {75, 89, 85, 70}},
            new Student {First = "Vladimir", Last = "Ivanov", Id = 113, Scores = new List<int> {97, 89, 89, 78}},
            new Student {First = "Alexandr", Last = "Petrov", Id = 114, Scores = new List<int> {100, 78, 95, 88}},
            new Student {First = "Julia", Last = "Smirnova", Id = 115, Scores = new List<int> {60, 78, 95, 80}},
            new Student {First = "Alexandr", Last = "Ovechkin", Id = 116, Scores = new List<int> {91, 78, 92, 71}},
            new Student {First = "Vladimir", Last = "Popov", Id = 117, Scores = new List<int> {90, 75, 94, 68}},
            new Student {First = "Sergei", Last = "Ivanov", Id = 118, Scores = new List<int> {97, 92, 81, 60}},
            new Student {First = "Sergei", Last = "Smirnov", Id = 119, Scores = new List<int> {97, 89, 89, 78}}
        };
        static void Main(string[] args)
        {
            IEnumerable<Student> studentQuery =
                from student in students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Last descending
                select student;

            foreach (Student student in studentQuery)
            {
                Console.WriteLine("{0}, {1} {2}", student.Last, student.First, student.Scores[0]);
            }

            var studentQuery2 =
                from student in students
                group student by student.Last[0];
            Console.WriteLine("\n");
            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (Student student in studentGroup)
                {
                    Console.WriteLine("{0}, {1}", student.Last, student.First);
                }
            }
        }
    }
}
