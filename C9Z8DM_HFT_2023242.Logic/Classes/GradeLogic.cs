using C9Z8DM_HFT_2023242.Models;
using C9Z8DM_HFT_2023242.Repository;
using System;
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
    }
}
