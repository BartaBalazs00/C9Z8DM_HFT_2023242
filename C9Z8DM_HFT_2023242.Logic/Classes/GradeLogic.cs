using C9Z8DM_HFT_2023242.Models;
using C9Z8DM_HFT_2023242.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace C9Z8DM_HFT_2023242.Logic
{
    public class GradeLogic : IGradeLogic
    {
        IRepository<Grade> repo;

        public GradeLogic(IRepository<Grade> repo)
        {
            this.repo = repo;
        }

        public void Create(Grade item)
        {
            if (item.TeacherId == 0 || item.StudentId == 0 || item.Year == 0 || item.GradeValue == 0 || item.Subject == null)
            {
                throw new ArgumentException("All properties must be given");
            }
            if (item.GradeValue > 5 || item.GradeValue < 1)
            {
                throw new ArgumentException("GradeValue must be between 1 and 5");
            }
            if (item.Year > DateTime.Now.Year)
            {
                throw new ArgumentException($"Year must be before {DateTime.Now.Year+1}");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Grade Read(int id)
        {
            var grade = this.repo.Read(id);
            if (grade == null)
            {
                throw new ArgumentException("Grade not exists");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Grade> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Grade item)
        {
            this.repo.Update(item);
        }


        //non cruds
        public double? GetAvarageGradesPerYear(int year)
        {
            return this.repo
                .ReadAll()
                .Where(x => x.Year == year)
                .Average(x=> x.GradeValue);
        }
        public double? GetAvarageGradesPerSubject(string subject)
        {
            return this.repo
                .ReadAll()
                .Where (x => x.Subject == subject)
                .Average(x => x.GradeValue);
        }
        public IEnumerable<GradeInfo> GetAvarageGradesPerStudents() 
        {
            return from x in this.repo.ReadAll()
                   group x by x.StudentId into g
                   select new GradeInfo()
                   {
                       Id = g.Key,
                       AvgGradeValue = g.Average(x => x.GradeValue)
                   };
        }
        public IEnumerable<GradeInfoPerSubject> GetAvarageGradesPerSubjects()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Subject into g
                   select new GradeInfoPerSubject()
                   {
                       Subject = g.Key,
                       AvgGradeValue = g.Average(x => x.GradeValue)
                   };
        }
        public int GetNumbersOfStudentsThatHasFailed()
        {
            return this.repo
                .ReadAll()
                .Where(x => x.GradeValue == 1)
                .Count();
        }
    }
    public class GradeInfoPerSubject
    {
        public string Subject { get; set; }
        public double? AvgGradeValue{ get; set; }
        public override bool Equals(object obj)
        {
            GradeInfoPerSubject gradeInfoPerSubject = obj as GradeInfoPerSubject;
            if (gradeInfoPerSubject == null)
            {
                return false;
            }
            else
            {
                return this.Subject == gradeInfoPerSubject.Subject
                    && this.AvgGradeValue == gradeInfoPerSubject.AvgGradeValue;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Subject, this.AvgGradeValue);
        }
    }
    public class GradeInfo
    {
        public int Id { get; set; }
        public double? AvgGradeValue { get; set; }
        public override bool Equals(object obj)
        {
            GradeInfo gradeInfo = obj as GradeInfo;
            if (gradeInfo == null)
            {
                return false;
            }
            else
            {
                return this.Id == gradeInfo.Id
                    && this.AvgGradeValue == gradeInfo.AvgGradeValue;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Id, this.AvgGradeValue);
        }
    }
}
