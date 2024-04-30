using System.Collections.Generic;
using System;
using System.Linq;
using ConsoleTools;
using C9Z8DM_HFT_2023242.Models;

namespace C9Z8DM_HFT_2023242.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Grade")
            {
                Console.Write("Enter studentId: ");
                int studentId = int.Parse(Console.ReadLine());
                Console.Write("Enter teacherId: ");
                int teacherId = int.Parse(Console.ReadLine());
                Console.Write("Enter subject: ");
                string subject = Console.ReadLine();
                Console.Write("Enter Grade: ");
                int grade = int.Parse(Console.ReadLine());
                Console.Write("Enter Year: ");
                int year = int.Parse(Console.ReadLine());
                try
                {
                    rest.Post(new Grade()
                    {
                        StudentId = studentId,
                        TeacherId = teacherId,
                        Subject = subject,
                        GradeValue = grade,
                        Year = year
                    }, "grade");
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                
            }
            else if(entity == "Student")
            {
                Console.Write("Enter student's name: ");
                string name = Console.ReadLine();
                Console.Write("Enter student's class: ");
                string studentClass = Console.ReadLine();
                try
                {
                    rest.Post(new Student()
                    {
                        StudentName = name,
                        StudentClass = studentClass
                    }, "student");
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
                
            }
            else if (entity == "Teacher")
            {
                Console.Write("Enter teacher's name: ");
                string name = Console.ReadLine();
                Console.Write("Enter teacher's subject: ");
                string subject = Console.ReadLine();
                Console.Write("Enter teacher's email: ");
                string email = Console.ReadLine();
                try
                {
                    rest.Post(new Teacher()
                    {
                        TeacherName = name,
                        Subject = subject,
                        Email = email
                    }, "teacher");
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }
        static void List(string entity)
        {
            if (entity == "Grade")
            {
                List<Grade> grades = rest.Get<Grade>("grade");
                foreach (Grade g in grades)
                {
                    Console.WriteLine("Id: " + g.GradeId + 
                        " - studentId: "+ g.StudentId +
                        " - teacherId: "+ g.TeacherId +
                        " - Subject: "+ g.Subject+
                        " - Grade: "+g.GradeValue
                        );
                }
            }
            else if(entity == "Teacher")
            {
                List<Teacher> teachers = rest.Get<Teacher>("teacher");
                foreach (Teacher teacher in teachers)
                {
                    Console.WriteLine(
                        "Id: " + teacher.TeacherId +
                        " - Name: " + teacher.TeacherName +
                        " - Subject: " + teacher.Subject +
                        " - Email: " + teacher.Email
                        );
                }
            }
            else if (entity == "Student")
            {
                List<Student> students = rest.Get<Student>("student");
                foreach (Student student in students)
                {
                    Console.WriteLine(
                        "Id: " + student.StudentId +
                        " - Name: " + student.StudentName +
                        " - Class: " + student.StudentClass
                        );
                }
            }
            Console.ReadKey();
        }
        static void Update(string entity)
        {
            if (entity == "Grade")
            {
                Console.Write("Enter Grade's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Grade grade = rest.Get<Grade>(id, "grade");
                Console.Write($"New grade [old:{grade.GradeValue}]: ");
                int gradeValue = int.Parse(Console.ReadLine());
                grade.GradeValue = gradeValue;
                try
                {
                    rest.Put(grade, $"grade");
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
            else if(entity == "Student")
            {
                Console.Write("Enter Student's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Student student = rest.Get<Student>(id, "student");
                Console.Write($"New student name [old: {student.StudentName}]: ");
                string name = Console.ReadLine();
                Console.Write($"New student class: [old: {student.StudentClass}]: ");
                string studentClass = Console.ReadLine();
                student.StudentClass = studentClass;
                student.StudentName = name;
                try
                {
                    rest.Put(student, "student");
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
            else if (entity == "Teacher")
            {
                Console.Write("Enter Teacher's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Teacher teacher = rest.Get<Teacher>(id, "teacher");
                Console.Write($"New teacher name [old: {teacher.TeacherName}]: ");
                string name = Console.ReadLine();
                Console.Write($"New teacher subject [old: {teacher.Subject}]: ");
                string subject = Console.ReadLine();
                Console.Write($"New teacher email [old: {teacher.Email}]: ");
                string email = Console.ReadLine();
                teacher.TeacherName = name;
                teacher.Subject = subject;
                teacher.Email = email;
                try
                {
                    rest.Put(teacher, "teacher");
                }
                catch (Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                }
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Grade")
            {
                Console.Write("Enter Grade's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "grade");
            }
            else if (entity == "Student")
            {
                Console.Write("Enter Student's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "student");
            }
            else if(entity == "Teacher")
            {
                Console.Write("Enter Teacher's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "teacher");
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:56516/", "grade");
            var gradeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Grade"))
                .Add("Create", () => Create("Grade"))
                .Add("Delete", () => Delete("Grade"))
                .Add("Update", () => Update("Grade"))
                .Add("Exit", ConsoleMenu.Close);
            var teacherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Teacher"))
                .Add("Create", () => Create("Teacher"))
                .Add("Delete", () => Delete("Teacher"))
                .Add("Update", () => Update("Teacher"))
                .Add("Exit", ConsoleMenu.Close);
            var studentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Student"))
                .Add("Create", () => Create("Student"))
                .Add("Delete", () => Delete("Student"))
                .Add("Update", () => Update("Student"))
                .Add("Exit", ConsoleMenu.Close);
            var menu = new ConsoleMenu(args, level: 0)
                .Add("Grades", () => gradeSubMenu.Show())
                .Add("Teachers", () => teacherSubMenu.Show())
                .Add("Students", () => studentSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);
            menu.Show();
        }
    }
}
