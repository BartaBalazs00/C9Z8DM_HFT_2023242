using C9Z8DM_HFT_2023242.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace C9Z8DM_HFT_2023242.Repository
{
    public class SchoolDbContext: DbContext
    {
        public DbSet<Student> Students { get;set; }
        public DbSet<Teacher> Teachers { get;set; }
        public DbSet<Grade> Grades { get;set; }
        public SchoolDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("school");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>(grade => grade
                .HasOne(grade => grade.Student)
                .WithMany(student => student.Grades)
                .HasForeignKey(grade => grade.StudentId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Grade>(grade => grade
                .HasOne(grade => grade.Teacher)
                .WithMany(teacher => teacher.Grades)
                .HasForeignKey(grade => grade.TeacherId)
                .OnDelete(DeleteBehavior.Cascade));
            modelBuilder.Entity<Student>().HasData(new Student[] {
                new Student { StudentId = 1, StudentName = "John Doe", StudentClass = "10A" },
                new Student { StudentId = 2, StudentName = "Jane Smith", StudentClass = "11B" },
                new Student { StudentId = 3, StudentName = "Michael Johnson", StudentClass = "9C" },
                new Student { StudentId = 4, StudentName = "Emily Brown", StudentClass = "12D" },
                new Student { StudentId = 5, StudentName = "Daniel Lee", StudentClass = "11A" },
                new Student { StudentId = 6, StudentName = "Sophia Wilson", StudentClass = "10B" },
                new Student { StudentId = 7, StudentName = "Ethan Martinez", StudentClass = "9A" },
                new Student { StudentId = 8, StudentName = "Olivia Taylor", StudentClass = "12C" },
                new Student { StudentId = 9, StudentName = "Liam Anderson", StudentClass = "11D" },
                new Student { StudentId = 10, StudentName = "Ava Thomas", StudentClass = "10C" }
            });
            modelBuilder.Entity<Teacher>().HasData(new Teacher[]
            {
                new Teacher { TeacherId = 1, TeacherName = "Mr. Johnson", Subject = "Math", Email = "johnson@example.com" },
                new Teacher { TeacherId = 2, TeacherName = "Ms. Parker", Subject = "Science", Email = "parker@example.com" },
                new Teacher { TeacherId = 3, TeacherName = "Mrs. Thompson", Subject = "History", Email = "thompson@example.com" },
                new Teacher { TeacherId = 4, TeacherName = "Mr. Davis", Subject = "English", Email = "davis@example.com" },
                new Teacher { TeacherId = 5, TeacherName = "Ms. Wilson", Subject = "Art", Email = "wilson@example.com" },
                new Teacher { TeacherId = 6, TeacherName = "Mr. Garcia", Subject = "Physical Education", Email = "garcia@example.com" },
                new Teacher { TeacherId = 7, TeacherName = "Mrs. Clark", Subject = "Biology", Email = "clark@example.com" },
                new Teacher { TeacherId = 8, TeacherName = "Ms. Adams", Subject = "Chemistry", Email = "adams@example.com" },
                new Teacher { TeacherId = 9, TeacherName = "Mr. Moore", Subject = "Physics", Email = "moore@example.com" },
                new Teacher { TeacherId = 10, TeacherName = "Mrs. Walker", Subject = "Music", Email = "walker@example.com" }
            });
            modelBuilder.Entity<Grade>().HasData(new Grade[]
            {
                // student 1
                new Grade { GradeId = 1, StudentId = 1, TeacherId = 1, Subject = "Math", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 2, StudentId = 1, TeacherId = 2, Subject = "Science", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 3, StudentId = 1, TeacherId = 3, Subject = "History", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 4, StudentId = 1, TeacherId = 4, Subject = "English", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 5, StudentId = 1, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 6, StudentId = 1, TeacherId = 6, Subject = "Physical Education", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 7, StudentId = 1, TeacherId = 7, Subject = "Biology", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 8, StudentId = 1, TeacherId = 8, Subject = "Chemistry", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 9, StudentId = 1, TeacherId = 9, Subject = "Physics", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 10, StudentId = 1, TeacherId = 10, Subject = "Music", GradeValue = 5, Year = 2022 },

                // student 2
                new Grade { GradeId = 11, StudentId = 2, TeacherId = 1, Subject = "Math", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 12, StudentId = 2, TeacherId = 2, Subject = "Science", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 13, StudentId = 2, TeacherId = 3, Subject = "History", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 14, StudentId = 2, TeacherId = 4, Subject = "English", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 15, StudentId = 2, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 16, StudentId = 2, TeacherId = 6, Subject = "Physical Education", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 17, StudentId = 2, TeacherId = 7, Subject = "Biology", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 18, StudentId = 2, TeacherId = 8, Subject = "Chemistry", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 19, StudentId = 2, TeacherId = 9, Subject = "Physics", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 20, StudentId = 2, TeacherId = 10, Subject = "Music", GradeValue = 3, Year = 2022 },
                //student 3
                new Grade { GradeId = 21, StudentId = 3, TeacherId = 1, Subject = "Math", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 22, StudentId = 3, TeacherId = 2, Subject = "Science", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 23, StudentId = 3, TeacherId = 3, Subject = "History", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 24, StudentId = 3, TeacherId = 4, Subject = "English", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 25, StudentId = 3, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 26, StudentId = 3, TeacherId = 6, Subject = "Physical Education", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 27, StudentId = 3, TeacherId = 7, Subject = "Biology", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 28, StudentId = 3, TeacherId = 8, Subject = "Chemistry", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 29, StudentId = 3, TeacherId = 9, Subject = "Physics", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 30, StudentId = 3, TeacherId = 10, Subject = "Music", GradeValue = 5, Year = 2022 },
                //student 4
                new Grade { GradeId = 31, StudentId = 4, TeacherId = 1, Subject = "Math", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 32, StudentId = 4, TeacherId = 2, Subject = "Science", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 33, StudentId = 4, TeacherId = 3, Subject = "History", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 34, StudentId = 4, TeacherId = 4, Subject = "English", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 35, StudentId = 4, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 36, StudentId = 4, TeacherId = 6, Subject = "Physical Education", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 37, StudentId = 4, TeacherId = 7, Subject = "Biology", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 38, StudentId = 4, TeacherId = 8, Subject = "Chemistry", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 39, StudentId = 4, TeacherId = 9, Subject = "Physics", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 40, StudentId = 4, TeacherId = 10, Subject = "Music", GradeValue = 5, Year = 2022 },
                //student 5
                new Grade { GradeId = 41, StudentId = 5, TeacherId = 1, Subject = "Math", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 42, StudentId = 5, TeacherId = 2, Subject = "Science", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 43, StudentId = 5, TeacherId = 3, Subject = "History", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 44, StudentId = 5, TeacherId = 4, Subject = "English", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 45, StudentId = 5, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 46, StudentId = 5, TeacherId = 6, Subject = "Physical Education", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 47, StudentId = 5, TeacherId = 7, Subject = "Biology", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 48, StudentId = 5, TeacherId = 8, Subject = "Chemistry", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 49, StudentId = 5, TeacherId = 9, Subject = "Physics", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 50, StudentId = 5, TeacherId = 10, Subject = "Music", GradeValue = 5, Year = 2022 },
                //student 6
                new Grade { GradeId = 51, StudentId = 6, TeacherId = 1, Subject = "Math", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 52, StudentId = 6, TeacherId = 2, Subject = "Science", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 53, StudentId = 6, TeacherId = 3, Subject = "History", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 54, StudentId = 6, TeacherId = 4, Subject = "English", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 55, StudentId = 6, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 56, StudentId = 6, TeacherId = 6, Subject = "Physical Education", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 57, StudentId = 6, TeacherId = 7, Subject = "Biology", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 58, StudentId = 6, TeacherId = 8, Subject = "Chemistry", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 59, StudentId = 6, TeacherId = 9, Subject = "Physics", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 60, StudentId = 6, TeacherId = 10, Subject = "Music", GradeValue = 5, Year = 2022 },
                //student 7
                new Grade { GradeId = 61, StudentId = 7, TeacherId = 1, Subject = "Math", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 62, StudentId = 7, TeacherId = 2, Subject = "Science", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 63, StudentId = 7, TeacherId = 3, Subject = "History", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 64, StudentId = 7, TeacherId = 4, Subject = "English", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 65, StudentId = 7, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 66, StudentId = 7, TeacherId = 6, Subject = "Physical Education", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 67, StudentId = 7, TeacherId = 7, Subject = "Biology", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 68, StudentId = 7, TeacherId = 8, Subject = "Chemistry", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 69, StudentId = 7, TeacherId = 9, Subject = "Physics", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 70, StudentId = 7, TeacherId = 10, Subject = "Music", GradeValue = 5, Year = 2022 },
                //student 8
                new Grade { GradeId = 71, StudentId = 8, TeacherId = 1, Subject = "Math", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 72, StudentId = 8, TeacherId = 2, Subject = "Science", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 73, StudentId = 8, TeacherId = 3, Subject = "History", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 74, StudentId = 8, TeacherId = 4, Subject = "English", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 75, StudentId = 8, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 76, StudentId = 8, TeacherId = 6, Subject = "Physical Education", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 77, StudentId = 8, TeacherId = 7, Subject = "Biology", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 78, StudentId = 8, TeacherId = 8, Subject = "Chemistry", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 79, StudentId = 8, TeacherId = 9, Subject = "Physics", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 80, StudentId = 8, TeacherId = 10, Subject = "Music", GradeValue = 5, Year = 2022 },
                //student 9
                new Grade { GradeId = 81, StudentId = 9, TeacherId = 1, Subject = "Math", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 82, StudentId = 9, TeacherId = 2, Subject = "Science", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 83, StudentId = 9, TeacherId = 3, Subject = "History", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 84, StudentId = 9, TeacherId = 4, Subject = "English", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 85, StudentId = 9, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 86, StudentId = 9, TeacherId = 6, Subject = "Physical Education", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 87, StudentId = 9, TeacherId = 7, Subject = "Biology", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 88, StudentId = 9, TeacherId = 8, Subject = "Chemistry", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 89, StudentId = 9, TeacherId = 9, Subject = "Physics", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 90, StudentId = 9, TeacherId = 10, Subject = "Music", GradeValue = 5, Year = 2022 },
                //student 10
                new Grade { GradeId = 91, StudentId = 10, TeacherId = 1, Subject = "Math", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 92, StudentId = 10, TeacherId = 2, Subject = "Science", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 93, StudentId = 10, TeacherId = 3, Subject = "History", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 94, StudentId = 10, TeacherId = 4, Subject = "English", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 95, StudentId = 10, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 96, StudentId = 10, TeacherId = 6, Subject = "Physical Education", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 97, StudentId = 10, TeacherId = 7, Subject = "Biology", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 98, StudentId = 10, TeacherId = 8, Subject = "Chemistry", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 99, StudentId = 10, TeacherId = 9, Subject = "Physics", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 100, StudentId = 10, TeacherId = 10, Subject = "Music", GradeValue = 5, Year = 2022 },
            });
        }

    }
}
