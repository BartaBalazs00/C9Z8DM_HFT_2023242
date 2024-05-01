using C9Z8DM_HFT_2023242.Models;
using C9Z8DM_HFT_2023242.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C9Z8DM_HFT_2023242.Logic
{
    public class StudentLogic : IStudentLogic
    {
        IRepository<Student> repo;

        public StudentLogic(IRepository<Student> repo)
        {
            this.repo = repo;
        }

        public void Create(Student item)
        {
            if (item.StudentName == null || item.StudentClass == null)
            {
                throw new ArgumentException("All properties must be given");
            }
            if (item.StudentName.Length < 5)
            {
                throw new ArgumentException("StudentName is too short");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Student Read(int id)
        {
            var student = this.repo.Read(id);
            if (student == null)
            {
                throw new ArgumentException("Student not exists");
            }
            return this.repo.Read(id);
        }

        public IQueryable<Student> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Student item)
        {
            this.repo.Update(item);
        }

        //Non CRUD

        public IEnumerable<ClassInfo> GetStudentsCountOfEachClass()
        {
            return from x in this.repo.ReadAll()
                   group x by x.StudentClass into g
                   select new ClassInfo()
                   {
                       StudentClass = g.Key,
                       Count = g.Count()
                   };
        }
    }
    public class ClassInfo
    {
        public string StudentClass { get; set; }
        public int Count { get; set; }
        public override bool Equals(object obj)
        {
            ClassInfo classInfo = obj as ClassInfo;
            if (classInfo == null)
            {
                return false;
            }
            else
            {
                return this.StudentClass == classInfo.StudentClass && this.Count == classInfo.Count;
            }
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(this.StudentClass, this.Count);
        }
    }
}
