using C9Z8DM_HFT_2023242.Logic;
using C9Z8DM_HFT_2023242.Models;
using C9Z8DM_HFT_2023242.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace C9Z8DM_HFT_2023242.Test
{
    [TestFixture]
    public class TestClass
    {
        GradeLogic gradeLogic;
        StudentLogic studentLogic;
        Mock<IRepository<Grade>> mockGradeRepository;
        Mock<IRepository<Student>> mockStudentRepository;
        SchoolDbContext ctx;
        [SetUp]
        public void Init()
        {
            
            ctx = new SchoolDbContext();
            var inputDataGrade = new List<Grade>()
            {
                new Grade { GradeId = 1, StudentId = 1, TeacherId = 1, Subject = "Math", GradeValue = 4, Year = 2020 },
                new Grade { GradeId = 2, StudentId = 1, TeacherId = 2, Subject = "Science", GradeValue = 3, Year = 2022 },
                new Grade { GradeId = 3, StudentId = 1, TeacherId = 3, Subject = "History", GradeValue = 5, Year = 2022 },
                new Grade { GradeId = 4, StudentId = 1, TeacherId = 4, Subject = "English", GradeValue = 2, Year = 2022 },
                new Grade { GradeId = 5, StudentId = 1, TeacherId = 5, Subject = "Art", GradeValue = 4, Year = 2022 },
                new Grade { GradeId = 6, StudentId = 2, TeacherId = 5, Subject = "Math", GradeValue = 5, Year = 2022 }
            }.AsQueryable();
            var inputDataStudent = new List<Student>()
            {
                new Student { StudentId = 1, StudentName = "John Doe", StudentClass = "10A" },
                new Student { StudentId = 2, StudentName = "Jane Smith", StudentClass = "10A" },
                new Student { StudentId = 3, StudentName = "Michael Johnson", StudentClass = "10B" },
                new Student { StudentId = 4, StudentName = "Emily Brown", StudentClass = "10B" }
            }.AsQueryable();
            ctx.AddRange(inputDataStudent);
            ctx.AddRange(inputDataGrade);
            mockGradeRepository = new Mock<IRepository<Grade>>();
            mockGradeRepository.Setup(m => m.ReadAll()).Returns(inputDataGrade);
            mockStudentRepository = new Mock<IRepository<Student>>();
            mockStudentRepository.Setup(m => m.ReadAll()).Returns(inputDataStudent);
            gradeLogic = new GradeLogic(mockGradeRepository.Object);
            studentLogic = new StudentLogic(mockStudentRepository.Object);
        }
        [Test]
        public void AvgGradePerYearTest()
        {
            double? avg = gradeLogic.GetAvarageGradesPerYear(2020);
            Assert.That(avg, Is.EqualTo(4));
        }
        [Test]
        public void AvgGradesPerSubjectTest()
        {
            double? avg = gradeLogic.GetAvarageGradesPerSubject("Math");
            Assert.That (avg, Is.EqualTo(4.5));
        }
        [Test]
        public void AvgGradesPerStudentsTest()
        {
            var result = gradeLogic.GetAvarageGradesPerStudents().ToList();
            var expected = new List<GradeInfo>()
            {
                new GradeInfo()
                {
                    Name = "John Doe",
                    AvgGradeValue = 3.6
                },
                new GradeInfo()
                {
                    Name = "Jane Smith",
                    AvgGradeValue = 5
                }
            };
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AvgGradesPerSubjectsTest()
        {
            var result = gradeLogic.GetAvarageGradesPerSubjects();
            var expected = new List<GradeInfoPerSubject>()
            {
                new GradeInfoPerSubject()
                {
                    Subject = "Math",
                    AvgGradeValue = 4.5
                },
                new GradeInfoPerSubject()
                {
                    Subject = "Science",
                    AvgGradeValue = 3
                },
                new GradeInfoPerSubject()
                {
                    Subject = "History",
                    AvgGradeValue = 5
                },
                new GradeInfoPerSubject()
                {
                    Subject = "English",
                    AvgGradeValue = 2
                },
                new GradeInfoPerSubject()
                {
                    Subject = "Art",
                    AvgGradeValue = 4
                }
            };
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void NumbersOfStudentsThatHasFailedTest()
        {
            int? count = gradeLogic.GetNumbersOfStudentsThatHasFailed();
            Assert.AreEqual(0, count);
        }
        [Test]
        public void CreateGradeTest()
        {
            var grade = new Grade()
            {
                GradeId = 7,
                StudentId = 1,
                TeacherId = 1,
                Subject = "Math",
                GradeValue = 5,
                Year = 2024
            };

            gradeLogic.Create(grade);
            mockGradeRepository.Verify(r => r.Create(grade), Times.Once);
        }
        [Test]
        public void CreateGradeWithWrongGradeValueTest()
        {
            var grade = new Grade()
            {
                GradeId = 7,
                StudentId = 1,
                TeacherId = 1,
                Subject = "Math",
                GradeValue = 6,
                Year = 2024
            };
            try
            {
                gradeLogic.Create(grade);
            }
            catch (Exception e)
            {
            }
            mockGradeRepository.Verify(r => r.Create(grade), Times.Never);
        }
        [Test]
        public void UpdateGradeWithGoodValueTest()
        {
            var grade = new Grade()
            {
                GradeId = 7,
                StudentId = 1,
                TeacherId = 1,
                Subject = "Math",
                GradeValue = 5,
                Year = 2024
            };
            gradeLogic.Create(grade);
            grade.GradeValue = 1;
            gradeLogic.Update(grade);
            mockGradeRepository.Verify(r => r.Update(grade), Times.Once);
        }
        [Test]
        public void StudentsCountOfEachClassTest()
        {
            var result = studentLogic.GetStudentsCountOfEachClass();
            var expected = new List<ClassInfo>()
            {
                new ClassInfo()
                {
                    StudentClass = "10A",
                    Count = 2,
                },
                new ClassInfo()
                {
                    StudentClass = "10B",
                    Count = 2,
                }
            };
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void CreateStudentTest()
        {
            var student = new Student() { StudentId = 5, StudentName = "Beviz Elek", StudentClass = "10A" };
            studentLogic.Create(student);
            mockStudentRepository.Verify(r => r.Create(student),Times.Once);
        }
    }
}
