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

            var studentQuery3 =
                from student in students
                group student by student.Last[0];
            Console.WriteLine("\n");
            foreach (var groupOfStudents in studentQuery3)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach(var student in groupOfStudents)
                {
                    Console.WriteLine("{0}, {1}", student.Last, student.First);
                }
            }

            var studentQuery4 =
                from student in students
                group student by student.Last[0] into studentGroup
                orderby studentGroup.Key
                select studentGroup;
            Console.WriteLine("\n");
            foreach (var groupOfStudents in studentQuery4)
            {
                Console.WriteLine(groupOfStudents.Key);
                foreach (var student in groupOfStudents)
                {
                    Console.WriteLine("{0}, {1}", student.Last, student.First);
                }
            }

            var studenQuery5 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                where totalScore/4<student.Scores[0]
                select student.Last + " " + student.First;
            Console.WriteLine("\n");
            foreach (string s in studenQuery5)
            {
                Console.WriteLine(s);
            }

            var studentQuery6 =
                from student in students
                let totalScore = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                select totalScore;
            double averageScore = studentQuery6.Average();
            Console.WriteLine("\n");
            Console.WriteLine("Class average score = {0}", averageScore);

            IEnumerable<string> studentQuery7 =
                from student in students
                where student.Last == "Ivanov"
                select student.First;
            Console.WriteLine("\nThe Ivanovs in the class are:");
            foreach (string s in studentQuery7)
            {
                Console.WriteLine(s);
            }

            var studentQuery8 =
                from student in students
                let x = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                where x > averageScore
                select new { id = student.Id, score = x };
            foreach(var item in studentQuery8)
            {
                Console.WriteLine("\nStudent ID: {0}, Score: {1}", item.id, item.score);
            }
        }
    }
}
