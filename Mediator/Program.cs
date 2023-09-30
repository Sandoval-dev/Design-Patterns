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
            Teacher teacher = new Teacher(mediator);
            teacher.Name = "Fasıl";
            mediator.teacher = teacher;

            Student student=new Student(mediator);
            student.Name = "Batuhan";


            Student student2 = new Student(mediator);
            student2.Name = "Ali";

            Student student3 = new Student(mediator);
            student3.Name = "Efe";

            mediator.students=new List<Student> { student,student2,student3};
            teacher.SendNewImageUrl("slide1.jpg");
            teacher.RecieveQuestion("How are you today?",student3);

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher:CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {

        }
        public string Name { get; set; }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved a question from {0}, {1}",student.Name,question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide: {0} ",url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer,Student student)
        {
            Console.WriteLine("Teacher answered question {0}, {1}", student.Name,answer);
        }

    }

    class Student:CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }

        public string Name { get; internal set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine("{1} received image: {0}",url,Name);
        }

        internal void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student received answer {0}",answer);
        }
    }

    class Mediator
    {
        public Teacher teacher { get; set; }
        public List<Student> students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }

    }
}
