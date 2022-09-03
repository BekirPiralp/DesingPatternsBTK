using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            
            Teacher teacher = new Teacher(mediator) { Name = "Hoca" };
            mediator.Teacher = teacher;

            mediator.Students = new List<Student> ();

            Student student = new Student(mediator) { Name = "Adsız" };
            mediator.Students.Add(student);

            Student student1 = new Student(mediator) { Name = "Engin" };
            mediator.Students.Add(student1);

            Student student2 = new Student(mediator) { Name = "Derin" };
            mediator.Students.Add(student2);

            Student student3 = new Student(mediator) { Name = "Salih" };
            mediator.Students.Add(student3);

            teacher.SendNewImage("slide1.jpg");
            teacher.RecieveQuestion("is it true?", student);
            Console.ReadLine();
        }
    }

    abstract class CoursMember
    {
        protected Mediator Mediator;
        public CoursMember(Mediator mediator)
        {
            Mediator = mediator;
        }
        public string Name { get; set; }
    }

    class Teacher : CoursMember
    {

        public Teacher(Mediator mediator):base ( mediator)
        {
        }

        internal void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine($"Teacher {Name} recivied a question from {student.Name},{question}");
        }

        public void SendNewImage(string url)
        {
            Console.WriteLine($"Teacher {Name} changed slide : {url}");
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine($"Teacher {Name} answered a question from {student.Name},{answer}");
        }
    }

    class Student : CoursMember
    {
        public Student(Mediator mediator): base(mediator)
        {
        }
        internal void RecieveImage(string url)
        {
            Console.WriteLine($"Student {Name} recivied image : {url}");
        }

        internal void RecieveAnswer(string answer)
        {
            Console.WriteLine($"Student {Name} received answer {answer}");
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string Url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(Url);
            }
        }

        public void SendQuestion(string question,Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }
    }
}
